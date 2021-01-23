     public Form2()
        {
            InitializeComponent();
            conn = "";
        }
      private void btnOK_Click(object sender, EventArgs e)
        {
             conn = CreateConn(conn, comboBox1.Text);
             SqlConnection connect = new SqlConnection(conn);
             MessageBox.Show(connect.ConnectionString.ToString());
        }
        public static string CreateConn(string connectString, string param)
        {
            connectString = String.Format("Data Source={0};Initial Catalog=db_Raspisanie;Integrated Security=True", 
                param);
            return connectString;
        }
