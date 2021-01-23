    using(var connection = new SqliteConnection("source.db"))
    {
        connection.Open();
        using(var command = connection.CreateCommand("select..."))
        {
            command.Execute...
            connection.Close();
        }
    }
