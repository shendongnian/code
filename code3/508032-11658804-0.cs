    public IEnumerable<IDataRecord> CreateQuery(string queryString, string connectionString)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                command.Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return (IDataRecord)reader;
                    }
                }
             }
        }
    }
