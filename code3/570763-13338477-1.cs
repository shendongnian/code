    private MySqlDataReader RunSqlQuery(string query, 
                                        Dictionary<string, string> queryParms)
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
                    reader = cmd.ExecuteReader();
                }
            }
        }
        catch (MySqlException ex)
        {
            // Oops.
        }
        return reader; //dont dont dont plss, instead return dataTable.Load(reader)
    }
