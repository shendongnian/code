    using (var connection = new SqlConnection("Your connection string here"))
    {
        connection.Open();
        using (var command = new SqlCommand("SELECT * FROM xyz ETC", connection))
        {                
            // Process results
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int userId = (int)reader["UserID"];
                    string somethingElse = (string)reader["AnotherField"];
                    // Etc, etc...
                }
            }
        }
        // To execute a query (INSERT, UPDATE, DELETE etc)
        using (var commandExec = new SqlCommand("DELETE * FROM xyz ETC", connection))
        {
            commandExec.ExecuteNonQuery();
        }
    }
