    protected override IDbCommand GetDbCommand(string key, IDbTransaction transaction)
    {
        if (transaction == null)
        {
            return base.GetDbCommand(key);
        }
        return transaction.Connection.CreateCommand();
    }
