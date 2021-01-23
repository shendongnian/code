    private static void ExecuteNonQuery(string queryString)
    {
        using (var connection = new SQLiteConnection(
                   ConnectionString))
        {
            using (var command = new SQLiteCommand(queryString, connection))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
