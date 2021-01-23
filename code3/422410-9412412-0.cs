    using (SqlConnection conn = new SqlConnection("CONNECTION_STRING"))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("TbaleName", conn);
        adapter.Fill(dataset);
        return dataset;
    }
