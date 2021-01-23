    public DataTable GetDataTableFromAdapter(string queryString)
    {
        DataTable dt = new DataTable();
        using (OdbcConnection connection =
                    new OdbcConnection(ConnectionString))
        {
            using (OdbcDataAdapter adapter =
                    new OdbcDataAdapter(queryString, connection))
            {
                connection.Open();
                adapter.Fill(dt);
            }
        }
        return dt;
    }
