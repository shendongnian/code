    query = "select count(*) from table where name = @name";
    MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ToString());
    connection.Open();
    MySqlCommand command = new MySqlCommand(query,connection);
    command.Parameters.Add("@name", name);
