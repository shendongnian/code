    using (var connection = new SqlConnection(connectionString))
    {
        var table = new DataTable("tbl_objects");
        var adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("SELECT * FROM tbl_name", connection);
        adapter.Fill(table);
    }
