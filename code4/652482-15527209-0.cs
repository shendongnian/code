    using (TransactionScope ts= new TransactionScope(TransactionScopeOption.RequiresNew))
    {
        using (SqlConnection connection1 = new SqlConnection(ConnectionString1))
        {
        }
        // At this point, connection1 is out of scope and disposed.
        using (SqlConnection connection2 = new SqlConnection(ConnectionString2))
        {
        }
        // At this point, connection2 is also out of scope and disposed.
        ts.Complete();
     }
