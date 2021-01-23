    var connection = new MySqlConnection("Data Source=server;UserId=root;PWD=pass;");
    var command = new MySqlCommand("CREATE DATABASE FancyDatabase;", connection);
    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
