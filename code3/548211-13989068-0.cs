    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
    {
       int k = Context.ExecuteStoreCommand("SET IDENTITY_INSERT dbo.client ON");
       Context.ClientInfoes.Add(testclient);
       result = Context.SaveChanges();
       scope.Complete();
       int j = Context.ExecuteStoreCommand("SET IDENTITY_INSERT dbo.client OFF");
    }
