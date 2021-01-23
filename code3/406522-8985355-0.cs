    private void ExecuteNonQuery(string commandText, string connString)
    {
        using(OracleConnection myOracleConnection = new OracleConnection(connString))
        {
            myOracleConnection.Open();
            OracleCommand command = myOracleConnection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = System.Data.CommandType.Text;
            command.ExecuteNonQuery();
        }
    }
