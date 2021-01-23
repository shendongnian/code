    string username;
    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
    {
        using (DataSet ds) 
        {
            adapter.Fill(ds);
            username = (string)ds.Tables[0].Rows[0]["mycolumnname"];
        }
    }
