    private IEnumerable<IDataRecord> RunSqlQuery(string query, 
                                                 Dictionary<string, string> queryParms)
    {
        MySqlDataReader reader = null;
        if (queryParms.Count > 0)
        {
            // Assign parameters
        }
        using (var dbConn = new MySqlConnection(config.DatabaseConnection))
        {
            using (var cmd = dbConn.CreateCommand())
            {
                dbConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                using (reader = cmd.ExecuteReader())
                    while(reader.Read())
                        yield return reader;
            }
        }
        return reader;
    }
