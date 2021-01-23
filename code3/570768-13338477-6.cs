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
				using (var reader = cmd.ExecuteReader())
					foreach (IDataRecord record in reader as IEnumerable)
						yield return record;
            }
        }
    }
