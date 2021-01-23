    using (var trans = new TransactionScope(
     TransactionScopeOption.Required, 
        new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadUncommitted
        }
    ))
    {
        // Your LINQ to SQL query goes here where you read some data from DB
    }
