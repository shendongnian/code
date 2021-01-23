     private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=.\\;Initial Catalog=TestDB;Integrated Security=SSPI;");
            string sqlQuery = @"SELECT * from Student" ;
            SqlCommand cmd = new SqlCommand(sqlQuery, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = new BindingSource(table, null);
            myConnection.Close();
        }
