    public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Project\Learning\Visual C#\Form\WindowsFormsApplication2\WindowsFormsApplication2\Test.mdb";
            conn.Open();
            string Name = textBox1.Text;
            OleDbCommand cmmd = new OleDbCommand("INSERT INTO table1 (student) Values(@Name)", conn);
            if (conn.State == ConnectionState.Open)
            {
                cmmd.Parameters.Add("@Name", OleDbType.VarWChar, 20).Value = Name;
                try
                {
                    cmmd.ExecuteNonQuery();
                    MessageBox.Show("DATA ADDED");
                    conn.Close();
                }
                catch (OleDbException expe)
                {
                    MessageBox.Show(expe.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("CON FAILED");
            }
        }
