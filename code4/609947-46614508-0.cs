    var connection = new MySqlConnection(ConfigurationManager.AppSettings["Test"]);
    connection.Open();
    var command = new MySqlCommand("SHOW SESSION STATUS LIKE \'Ssl_cipher\'", connection);
    MySqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(0));
    }
