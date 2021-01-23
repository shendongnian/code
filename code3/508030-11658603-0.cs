    public DataTable CreateQuery(string queryString, string connectionString )
        {
            DataTable results =  new DataTable("Results");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
    
                    MySqlDataReader reader = command.ExecuteReader();
                    results.Fill(reader);
                }
            }
           return results;
        }
