    DataTable dt = new DataTable();
    
    using (SqlConnection con = new SqlConnection(myConnection.GetConnectionString()))
    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM zajezd", con))
    {
        adapter.Fill(dt);
    }
