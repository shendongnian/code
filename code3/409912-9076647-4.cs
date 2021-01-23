    DataTable Table = new DataTable();
    
    SqlConnection Connection = new SqlConnection("ConnectionString");
    //I assume you know better what is your connection string
    
    SqlDataAdapter adapter = new SqlDataAdapter("Select * from " + TableName, Connection);
    
    adapter.Fill(Table);
