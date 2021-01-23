    private void Insert()
    {
        string connStr = "server=server; " +
                     "database=databasename; " +
                     "uid=username; " +
                     "pwd=password;";
        string query = "INSERT INTO TableName('Name','Score) VALUES (@name, @score);";
        using(MySqlConnection connection = new MySqlConnection(connStr))
        {
            MySqlCommand insertCommand = new MySqlCommand(connection,command);
            insertCommand.Paramaters.AddWithValue("@name",sName);
            insertCommand.Paramaters.AddWithValue("@score",iTotalScore);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
       }
    }
