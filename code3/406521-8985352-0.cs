    private static void ExecuteSQL(string SQL)
    {
      OracleConnection myOracleConnection = new OracleConnection(connectionString);
      myOracleConnection.Open();
      OracleCommand command = myOracleConnection.CreateCommand();
      command.CommandText = SQL;
      command.CommandType = System.Data.CommandType.Text;
      command.ExecuteNonQuery();
      myOracleConnection.Close(); 
    }
