    using MySql.Data.MySqlClient;
    string dbConnectionString = "SERVER=server_address;DATABASE=db_name;UID=user;PASSWORD=pass;";
    MySqlConnection connection = new MySqlConnection(dbConnectionString);
    connection.Open();
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "select name from mytable";
    MySqlDataReader Reader = command.ExecuteReader();    
    while (Reader.Read())
    {
         string name = "";
         if (!Reader.IsDBNull(0))
             name = (string)Reader["name"];
    }
    Reader.Close();
