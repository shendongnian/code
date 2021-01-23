    public virtual int ExecuteNonQuery(DbCommand command)
    {
        using (var wrapper = GetOpenConnection())
        {
            PrepareCommand(command, wrapper.Connection);
            return DoExecuteNonQuery(command);
        }
    }
    protected DatabaseConnectionWrapper GetOpenConnection()
    {
        DatabaseConnectionWrapper connection = TransactionScopeConnections.GetConnection(this);
        return connection ?? GetWrappedConnection();
    }
