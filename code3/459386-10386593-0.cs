    public static DbDataReader Query(
        string connectionString, string selectCommand)
    {
        var connection = new OleDbConnection(connectionString);
        var command = new OleDbCommand(selectCommand, connection);
        var result = command.ExecuteReader();
        return result;
    }
