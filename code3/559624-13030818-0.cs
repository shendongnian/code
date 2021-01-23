    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Fetch();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T Single(Func<T, bool> predicate);
        T First(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void Detach(T entity);
        void UpdateChanges(T entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
    }
    public class DataRepository<T> : IRepository<T> where T : class
    {
        private ObjectContext _context;
        private IObjectSet<T> _objectSet;
        public DataRepository()
            : this(new ModelContainer()) //ModelContainer is the name of the EF model class.
        {
        }
        public DataRepository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }
        public IQueryable<T> Fetch()
        {
            return _objectSet;
        }
        public IEnumerable<T> GetAll()
        {
            return Fetch().AsEnumerable();
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _objectSet.Where<T>(predicate);
        }
        public T Single(Func<T, bool> predicate)
        {
            return _objectSet.Single<T>(predicate);
        }
        public T First(Func<T, bool> predicate)
        {
            return _objectSet.First<T>(predicate);
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.DeleteObject(entity);
        }
        public void Delete(Func<T, bool> predicate)
        {
            IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;
            foreach (T record in records)
            {
                _objectSet.DeleteObject(record);
            }
        }
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.AddObject(entity);
        }
        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }
        public void Detach(T entity)
        {
            _objectSet.Detach(entity);
        }
        public void UpdateChanges(T entity)
        {
            Add(entity);
            _context.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
