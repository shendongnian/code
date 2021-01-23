     DatabaseContext db1 = new DatabaseContext();
     doSomeDatabaseActions(db1);
     TransactionOptions transOpts = new TransactionOptions();
     transOpts.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
     using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transOpts))
     {
         using (DatabaseContext db2 = new DatabaseContext())
         {
            doDatabaseChecksWithLock(db2);
            doChanges(db2);
            db2.SaveChanges();
         }
         scope.Complete();
      }
