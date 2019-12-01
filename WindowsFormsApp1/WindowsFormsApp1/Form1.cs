using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_button_Click(object sender, EventArgs e)
        {

            // con 객체 DB 연결.
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jeahun\Desktop\Dev\Winform_1\WindowsFormsApp1\Data5.mdf;Integrated Security=True;Connect Timeout=30");

            // sda 객체를 활용하여 원하는 자료를 뽑아낸다.
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO where USERNAME='" + ID_text.Text + "' and PASSWORD = '" + PW_text.Text + "'", con);

            // 새로운 테이블 생성 , sda 데이터 담는 용도.
            DataTable newTable = new DataTable();

            sda.Fill(newTable);

            if (newTable.Rows[0][0].ToString() == "1") // 데이터가 있을경우
            {
                //로그인 성공
                //this.Hide;
                Mainform mainform1 = new Mainform();
                mainform1.Show();
            }
            else
            {
                //로그인 실패
                MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다.");
            }

            //this.Hide();



        }
    }
}
