    IDataReader GetReader(...)
    {
        IDbConnection connection = ...;
        try
        {
            IDbCommand command = ...;
            command.Connection = connection;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            connection.Close();
            throw;
        }
    }
