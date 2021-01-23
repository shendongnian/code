    string commandLine = "SELECT * FROM Table WHERE active=1";
    commandLine = commandLine.Remove(commandLine.Length - 3);
    using(MySqlConnection connect = new MySqlConnection(connectionStringMySql))
    using(MySqlCommand cmd = new MySqlCommand(commandLine, connect))
    {
        connect.Open();
        using(MySqlDataReader msdr = cmd.ExecuteReader())
        {
            while (msdr.Read())
            {
                //Read data
            }
        }
    } // Here the connection will be closed and disposed.  (and the command also)
