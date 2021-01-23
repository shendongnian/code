    public void Do(IUnitOfWork uow)
    {
      using (var tx = uow.BeginTransaction()) {
        // DAL calls
        tx.Commit();
      }
    }
