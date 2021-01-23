    private void LoadList()
        {
            List<string> tagsList = new List<string>();
    
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DBConnectionString))
            {
                connection.Open();    
    
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Tag FROM TagsTable";
    
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                tagsList.Add(reader.GetString(0));
                        }
    
                        reader.Close();
                    }
                }
    
                connection.Close();
            }
        }
