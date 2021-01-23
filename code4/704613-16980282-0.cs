    using System;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient; //using the mysql dll
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string connectionString = "Data Source=localhost;Initial Catalog=myDb;User ID=MyUser;Password=MyPass";
                MySqlConnection cnn = new MySqlConnection(connectionString);
                try
                {
                    cnn.Open();
                    MessageBox.Show("Connection Open ! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                    MessageBox.Show(ex.Message); //shows what error actually occurs
                }
                finally
                {
                    cnn.Close();
                }
            }
        }
    }
