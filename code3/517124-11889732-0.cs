    using (var scope = new TransactionScope())
    {
            using(TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Suppress)) {
               ToDo1();
               scope2.Complete();
            }
     
            // If ToDo2 throws an exception and the transaction is rolled back,
            // ToDo1 will still be committed since it did not participate in the
            // original (ambient) transaction.
            ToDo2();       
            scope.Complete();
    }
