    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    using (SQLiteCommand command = new SQLiteCommand(connection))
    {
        command.CommandText = "...";
    
        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        command.Parameters.Add("@surname", SqlDbType.NVarChar).Value = value;
    
        connection.Open();
        command.ExecuteNonQuery();
    }
