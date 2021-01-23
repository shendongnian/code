    using(MySqlConnection connect = new MySqlConnection(connectionStringMySql))
    using(MySqlCommand cmd = new MySqlCommand())
    {
        string commandLine = "SELECT * FROM Table WHERE active=1";
        commandLine = commandLine.Remove(commandLine.Length - 3);
        cmd.CommandText = commandLine;
        cmd.Connection = connect;
        cmd.Connection.Open();
        msdr = cmd.ExecuteReader();
        while (msdr.Read())
        {
            //Read data
        }
    } // Here the connection will be closed and disposed.  (and the command also)
