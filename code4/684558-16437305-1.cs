        using(var scope = new TransactionScope(TransactionScopeOption.Required,
            new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted })){
        
            // Do something 
            context.SaveChanges();
            // Do something else
            context.SaveChanges();
        
            scope.Complete();
    }
