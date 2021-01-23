    private delegate void CommandAction(OracleCommand command);
    private static void ExecuteNonQuery(CommandAction action)
    {
      OracleConnection myOracleConnection = new OracleConnection(connectionString);
      myOracleConnection.Open();
      OracleCommand command = myOracleConnection.CreateCommand();
      action(command);
      command.ExecuteNonQuery();
      myOracleConnection.Close(); 
    }
