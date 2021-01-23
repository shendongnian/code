    public OleDbCommand CreateMyOleDbCommand(OleDbConnection connection,
        string queryString, OleDbParameter[] parameters) 
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Parameters.AddRange(parameters);
        return command;
    }
