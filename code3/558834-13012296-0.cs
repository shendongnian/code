    using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnectionString))
    {
        connection.Open();
        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = "delete from table1";
        command.ExecuteNonQuery();
        command.Dispose();
        connection.Close();
    }
