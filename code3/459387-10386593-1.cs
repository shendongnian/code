    public static DbDataReader Query(
        string connectionString, string selectCommand, 
        params KeyValuePair<string, object>[] parameters)
    {
        var connection = new OleDbConnection(connectionString);
        var command = new OleDbCommand(selectCommand, connection);
        
        foreach (var p in parameters)
            command.Parameters.Add(new OleDbParameter(p.Key, p.Value));
        var result = command.ExecuteReader();
        return result;
    }
