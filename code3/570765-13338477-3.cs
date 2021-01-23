    private IEnumerable<IDataRecord> RunSqlQuery(string query, 
                                                 Dictionary<string, string> queryParms)
    {
        using (var dbConn = new MySqlConnection(config.DatabaseConnection))
        {
            using (var cmd = dbConn.CreateCommand())
            {
                if (queryParms.Count > 0)
                {
                    // Assign parameters
                }
                cmd.CommandText = query;
                cmd.Connection.Open();
                using (reader = cmd.ExecuteReader())
                    while(reader.Read())
                        yield return reader;
            }
        }
        return reader;
    }
