    public List<string> MySqlCollectionQuery(MySqlConnection connection, string cmd)
    {
        List<string> QueryResult = new List<string>();
        MySqlCommand cmdName = new MySqlCommand(cmd, connection);
        MySqlDataReader reader = cmdName.ExecuteReader();
        while (reader.Read())
        {
            QueryResult.Add(reader.GetString(0));
        }
        reader.Close();
        return QueryResult;
    }
