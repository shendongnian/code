    protected override IDbCommand GetDbCommand(string key, IDbTransaction transaction)
    {
        if (transaction == null)
        {
            return base.GetDbCommand(key);
        }
        var cmd = transaction.Connection.CreateCommand(); 
        cmd.Transaction = transaction; 
        return cmd;
    }
