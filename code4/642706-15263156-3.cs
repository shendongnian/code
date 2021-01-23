    private void QueryDatabase(string connectionString, string commandText, IParameterizable parameters)
    {
        using(var connection = new SqlConnection(connectionString))
        using(var command = connection.CreateCommand())
        {
            command.CommandText = commandText;
            command.Parameters.AddRange(parameters.GetParameters());
            command.CommandType = CommandType.StoredProcedure;
            connection.Open()
            command.ExecuteNonQuery();
        }
        
    }
