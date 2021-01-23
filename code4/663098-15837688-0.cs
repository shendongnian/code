    using (MySqlConnection connection = new MySqlConnection(strConnect))
    {
        connection.Open();
        using (MySqlCommand command = new MySqlCommand(query, connection))
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString("name"));
            }
        }
        connection.Close();
    }
