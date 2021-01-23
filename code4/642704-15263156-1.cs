    private void QueryDatabase(string connectionString, string commandText, IDictionary<string, object> parameters)
    {
        using(var connection = new SqlConnection(connectionString))
        using(var command = connection.CreateCommand())
        {
            command.CommandText = commandText;
            command.Parameters.AddRange(parameters.Select(l => new SqlParameter(l.Key, l.Value)));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open()
            command.ExecuteNonQuery();
        }
        
    }
