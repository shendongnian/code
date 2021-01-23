    class UnitOfWork
    {
         ClubSpotEntities _dbContext;
         TransactionScope _transaction;
         public UnitOfWork()
         {
             _dbContext = new ClubSpotEntities();
             _transaction = new TransactionScope();
         }
         public void Complete()
         {
             _dbContext.SaveChanges();
             _transaction.Complete();
         }
         ...
    }
