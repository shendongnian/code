    using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnectionString))
    {
        connection.Open();
        connection.BeginTransaction(IsolationLevel.ReadCommitted);
    
        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = "delete from table1";
        command.ExecuteNonQuery();
    }
