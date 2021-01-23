    using System.Data.SqlClient;
    
    namespace StackTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string connectionString = @"Data Source=(localdb)\Projects;Initial Catalog=DbTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
                string selectString = "select * from TblTest";
                textBox1.Multiline = true;
    
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(selectString,conn);
    
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
    
                while (rdr.Read())
                {
                    textBox1.Text += rdr[0];
                    textBox1.Text += rdr[1];
                    //...
                    textBox1.Text += Environment.NewLine;
                }
    
                conn.Close();
    
    
                
            }
        }
    }
