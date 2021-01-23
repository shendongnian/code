    using(SqlDataAdapter sqlDataAdapter = 
        new SqlDataAdapter("SELECT * FROM Table1",
            "Server=.\\SQLEXPRESS; Integrated Security=SSPI; Database=SampleDb"))
    {
        using (DataTable dataTable = new DataTable())
        {
            sqlDataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
        }
    }
