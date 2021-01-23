    using (var tran = new TransactionScope())
    using (var conn = new SqlConnection(YourConnectionString))
    using (var insetCommand1 = conn.CreateCommand())
    using (var insetCommand2 = conn.CreateCommand())
    {
        insetCommand1.CommandText = \\SQL to insert
    
        insetCommand2.CommandText = \\SQL to insert
    
        insetCommand1.ExecuteNonQuery();
    
        insetCommand2.ExecuteNonQuery();
    
        tran.Complete();
    }
