    using (var ctx = GetContext())
    {
        using (var transactionScope = new TransactionScope())
        {
            // some stuff in dbcontext    
            ctx.BulkInsert(entities);    
            ctx.SaveChanges();
            transactionScope.Complete();
        }
    }
