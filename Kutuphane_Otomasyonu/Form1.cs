using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kutuphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=kutuphane;UID=root;PASSWORD='';"); // Buraya bağlantı satırı gelecek.
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();   // buraya programı ortalama kodu gelecek.
              yayin_tarihi.Value.Date.ToString("dd/MM/yyyy");
        }
        Form2 f2;

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_kitapadi.Text == "" || txt_yazar.Text == "" || cmb_yayinevi.Text == "" || cmb_k_dili.Text == "" || cmb_kategori.Text == "" || cmb_raf.Text == "" || cmb_sira.Text == "")
            {
                lbl_sonuc.Text = "Lütfen boş alanları doldurunuz!";
            }
            else
            {

                try
                {
                    string kitap_adi = txt_kitapadi.Text;
                    string k_dili = cmb_k_dili.Text;
                    string yazar = txt_yazar.Text;
                    string yayin_tarihi = this.yayin_tarihi.Text;
                    string yayinevi = cmb_yayinevi.Text;
                    string kategory = cmb_kategori.Text;
                    string raf = cmb_raf.Text;
                    int sira = Convert.ToInt32(cmb_sira.Text);
                    string kitap_ozet = txt_ozet.Text;

                    string cmdText = "INSERT INTO kitaplar VALUES (@kitap_id, @kitap_adi,@kitap_dili,@kitap_yazari,@kitap_tarihi,@kitap_yayinevi,@kitap_kategori,@kitap_raf,@kitap_sira,@kitap_ozet)";
                    MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                    cmd.Parameters.AddWithValue("@kitap_id", "");
                    cmd.Parameters.AddWithValue("@kitap_adi", kitap_adi);
                    cmd.Parameters.AddWithValue("@kitap_dili", k_dili);
                    cmd.Parameters.AddWithValue("@kitap_yazari", yazar);
                    cmd.Parameters.AddWithValue("@kitap_tarihi", yayin_tarihi);
                    cmd.Parameters.AddWithValue("@kitap_yayinevi", yayinevi);
                    cmd.Parameters.AddWithValue("@kitap_kategori", kategory);
                    cmd.Parameters.AddWithValue("@kitap_raf", raf);
                    cmd.Parameters.AddWithValue("@kitap_sira", sira);
                    cmd.Parameters.AddWithValue("@kitap_ozet", kitap_ozet);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    lbl_sonuc.Text = "Kayıt Yapıldı";
                    //gridview_data(); // kaydı yapınca listeyi yenilemeyi yapıyor
                }
                catch (Exception hata)
                {
                    lbl_sonuc.Text = "Kayıt Yapılamadı" + hata + ""; // hata kelimesi kodunu gösterir.
                }
            }
        }
        
              public void combobox_list(){
            /*
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=.;Initial Catalog=kutuphane;Integrated Security=SSPI";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM kitap";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            
            */
            MySqlCommand mycom = new MySqlCommand("select kategori_id, kategori_adi from kitaplar_kategori", connection);
            connection.Open();
            MySqlDataReader dr = mycom.ExecuteReader();
            while (dr.Read())
            {
                cmb_kategori.Items.Add(dr["kategori_adi"]);
            }
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDataSet2.kitaplar_kategori' table. You can move, or remove it, as needed.
            combobox_list();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
