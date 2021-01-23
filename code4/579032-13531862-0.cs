    using (var dbConnection = new SqliteConnection (@"..."))
    {
        dbConnection.Open();
        string sql = @"INSERT INTO ""queue"" (""data"") VALUES(""Test"")";
        using (var insertCommand = new SqliteCommand (sql, dbConnection))
        {
            insertCommand.ExecuteNonQuery();
        }
    }
