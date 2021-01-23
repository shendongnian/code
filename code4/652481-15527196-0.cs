    using (TransactionScope ts= new TransactionScope(TransactionScopeOption.RequiresNew))
    using (SqlConnection connection1 = new SqlConnection(ConnectionString1))
    using (SqlConnection connection2 = new SqlConnection(ConnectionString2))
    {
        // ...
        ts.Complete()
    }
