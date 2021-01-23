    using (SqlConnection conn = new SqlConnection(connection))
    {
        DataSet dataset = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("MyProcedure", conn);
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        adapter.Fill(dataset);
        return dataset;
    }
