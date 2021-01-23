    DataTable table = new DataTable();
    string sql = "SELECT Col2, Col3 FROM myTable WHERE Col1=0";
    using (SqlConnection conn = new SqlConnection(mySqlCalss.DatabaseConnectionString() ))
    {
       SqlCommand cmd = new SqlCommand(sql, conn);
       cmd.Connection.Open();
       SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       adapter.Fill(table);                
    }
