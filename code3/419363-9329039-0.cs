    public class NHibernateUnitOfWork : IDisposable
    {
        public NHibernateUnitOfWork(ISession session)
        {
            _transaction = session.BeginTransaction();
        }
        public void SaveChanges()
        {
            _transaction.Commit();
            _saved = true;
        }
        public void Dispose()
        { 
            _transaction.Dispose();
        }
    }
