    public partial class add_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SPT6GLG\SQLEXPRESS;Initial Catalog=library_managment;Integrated Security=True;Pooling=False");
       
        public add_student_info()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into student_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student recorc addedd sussfully");
            
            }
        }
    }
