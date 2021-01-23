    DataSet ds = new DataSet();
    using (SqlConnection connection =  new SqlConnection("your-Connection-String-here"))
    {
        
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("myStoredProcedure", connection);
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        adapter.SelectCommand.Parameters.AddWithValue("@unitItems",20);
        //add other parameters as above here
        adapter.SelectCommand.Parameters.AddWithValue("@page",1); //correct page number
        adapter.Fill(ds);
    }
    //Now you can access all query results as 
    ds.Tables[0]; //results from query1
    ds.Tables[1]; //results from query2
    ds.Tables[2]; //results from query3
