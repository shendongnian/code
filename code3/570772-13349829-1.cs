    private bool RunSqlQuery(string query, Func<MySqlDataReader, bool> readerAction)
    {
        Dictionary<string, string> queryParms = new Dictionary<string, string>();
        return RunSqlQuery(query, readerAction, queryParms);
    }
    private bool RunSqlQuery(string query, Func<MySqlDataReader, bool> readerAction, Dictionary<string, string> queryParms)
    {
        MySqlDataReader reader = null;
        if (queryParms.Count > 0)
        {
            // Assign parameters
        }
        try
        {
            using (var dbConn = new MySqlConnection(config.DatabaseConnection))
            {
                using (var cmd = dbConn.CreateCommand())
                {
                    dbConn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using (reader = cmd.ExecuteReader())
                    {
                        return readerAction.Invoke(reader);
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            // Oops.
            return false;
        }
    }
