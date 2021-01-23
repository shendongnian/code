    public IDataReader getRecord(string query)
        {
            MySqlDataReader reader;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load( reader );
                    return dt.CreateDataReader();
                }
            }
            return null;
        }
