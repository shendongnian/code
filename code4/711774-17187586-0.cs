        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
              connection.Open();
              using (OracleCommand oracleCommand = new OracleCommand(procedureName, connection);)
              {
                   oracleCommand.CommandType = CommandType.StoredProcedure;
                   oracleCommand.ExecuteNonQuery();
              }
        }
