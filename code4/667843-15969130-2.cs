    public IDataReader ExecuteDataReader(string commandText)
    {
        IDbConnection connection = _connectionManager.GetConnection();
        return ExecuteDataReader(commandText, connection);   **//error shows**
    }
