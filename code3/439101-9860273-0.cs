    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using(SqlCommand command = new SqlCommand(queryString, connection)
        {
            connection.Open();
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // do something with it
                }
            }
        }
    }
