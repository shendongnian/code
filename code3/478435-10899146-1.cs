    public class NhibernateUnitOfWork : IUnitOfWork
    {
      private readonly ISession _session;
      private ITransaction _transaction;
     
      public NhibernateUnitOfWork(ISession session)
      {
        _session = session;
        _transaction = session.BeginTransaction();
      }
     
      public void Dispose()
      {
        if (_transaction == null)
          return;
     
        if (!_transaction.WasCommitted)
          _transaction.Rollback();
     
        _transaction.Dispose();
        _transaction = null;
      }
     
      public void SaveChanges()
      {
        _transaction.Commit();
      }
     
    }
