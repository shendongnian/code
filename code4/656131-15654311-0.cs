    DataView dv = new DataView();
            public Form1()
            {
                InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\Programy\Baza Danych Kontakty\Dane.accdb";
            connect.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            command.CommandText = "SELECT FirmaKod,FirmaNazwa FROM Firma";
            OleDbDataReader reader = command.ExecuteReader();
            datatable.Load(reader);
            dataGridView1.DataSource = dv = datatable.DefaultView;
            connect.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
            {
                dv.RowFilter = "FirmaNazwa like '%" + textBox1.Text + "%'";
                if (textBox1.Text == "") dv.RowFilter = string.Empty;
            }`
