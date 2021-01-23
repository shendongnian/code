    SQLiteConnection connection = new SQLiteConnection("Data Source=" + file);
    connection.Open();
    using (var command = new SQLiteCommand(sqliteConnection))
    {
        command.CommandText = "PRAGMA journal_mode=WAL";
        command.ExecuteNonQuery();
    }
    // (Perform my query)
