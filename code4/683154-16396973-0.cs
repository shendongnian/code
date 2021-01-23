    public DataSet SelectRows(DataSet dataset,string connection,string query) 
    {
        MySqlConnection conn = new MySqlConnection(connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = new MySqlCommand(query, conn);
        adapter.Fill(dataset);
        return dataset;
    }
