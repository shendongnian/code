    void M1() 
    {
        using( var scope = TransactionManager.BeginTransaction() )
        {
          // Do stuff with the database.
          M2(); // M2 and M3 each create their own scopes that share the transaction
          M3(); // created by M1.
    
          // An exception before the commit will cause the transaction to roll back.
          scope.Commit();
        }
    }
