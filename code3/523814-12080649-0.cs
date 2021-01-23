    using (var connection = new MySqlConnection("server=localhost;user=root;password="))
    {
        connection.Open();
    
        var command = connection.CreateCommand();
        command.CommandText = "drop schema if exists clusters";
        command.ExecuteNonQuery();
    
        command = connection.CreateCommand();
        command.CommandText = "create schema clusters";
        command.ExecuteNonQuery();
    }
