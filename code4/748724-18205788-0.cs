    String connString = @"your connection string here";
    String query = "select * from table";
    
    SqlConnection conn = new SqlConnection(connString);        
    SqlCommand cmd = new SqlCommand(query, conn);
    conn.Open();
    **Using(SqlDataAdapter da = new SqlDataAdapter(cmd))
    {
        da.Fill(dataTable);
        conn.Close();
    }**
