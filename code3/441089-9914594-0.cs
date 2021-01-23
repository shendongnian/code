    public class NhUnitOfWork : IUnitOfWork
    {
        readonly ISession _session;
        
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new NhRepository<T>(_session);
        }
        
        public NhUnitOfWork(ISession session)
        {
            _session = session;
        }
        
        public void Dispose()
        {
            // Dispose logic, i.e. save/rollback
        }
    }
    
    public class NhRepository<T> : IRepository<T> where T : class
    {
        readonly ISession _session;
        
        public void Add(T item)
        {
            _session.Save(item);
        }
        
        public void Delete(T item)
        {
            _session.Delete(item);
        }
        
        public void Update(T item)
        {
            _session.Update(item);
        }
        
        public NhRepository(ISession session)
        {
            _session = session;
        }
    }
