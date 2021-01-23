    using(MySqlConnection connect = new MySqlConnection(connectionStringMySql))
    using(MySqlCommand cmd = new MySqlCommand())
    {
        string commandLine = "SELECT id,token FROM Table WHERE id = @id AND token = @token;";
        cmd.CommandText = commandLine;
    
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@token", token);
    
        cmd.Connection = connect;
        cmd.Connection.Open();
    
        using(msdr = cmd.ExecuteReader())
        {
    
             //do stuff.....
        } // <- here the DataReader is closed and disposed.
    }  // <- here at the closing brace the connection is closed and disposed as well the command
