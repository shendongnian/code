    using(var con = new SqlConnection(connectionString))
    using(var adapter = new SqlDataAdapter(sql, con))
    {
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }
