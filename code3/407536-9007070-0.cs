    using MySql.Data.MySqlClient;
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
