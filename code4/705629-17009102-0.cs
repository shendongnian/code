       using (SqlConnection connection = new SqlConnection(connectionString))
        {
            List<string> sqlCommandList = new List<string>();
            connection.Open();
            Parallel.ForEach(sqlCommandList, commandString =>
            {
                SqlCommand command = new SqlCommand(commandString, connection);
                command.ExecuteNonQuery();
            });
        }
