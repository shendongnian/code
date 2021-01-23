    using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
       //Run some code here, like calling an async method
       await someAsnycMethod();
       transaction.Complete();
    } 
