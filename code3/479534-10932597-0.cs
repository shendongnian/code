    public class UnitOfWorkFactory
        {
            private static readonly Hashtable _threads = new Hashtable();
            private const string HTTPCONTEXTKEY = "AboutDbContext.UnitOfWorkFactory";
    
            public static IUnitOfWork Create()
            {
                IUnitOfWork unitOfWork = GetUnitOfWork();
    
                if (unitOfWork == null || unitOfWork.IsDisposed)
                {
                    unitOfWork = new UnitOfWork();
                    SaveUnitOfWork(unitOfWork);
                }
                return unitOfWork;
            }
    
            public static IUnitOfWork GetUnitOfWork()
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items.Contains(HTTPCONTEXTKEY))
                    {
                        return (IUnitOfWork)HttpContext.Current.Items[HTTPCONTEXTKEY];
                    }
                    return null;
                }
    
                var thread = Thread.CurrentThread;
    
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
    
                lock (_threads.SyncRoot)
                {
                    return (IUnitOfWork)_threads[Thread.CurrentThread.Name];
                }
            }
    
            private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[HTTPCONTEXTKEY] = unitOfWork;
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        _threads[Thread.CurrentThread.Name] = unitOfWork;
                    }
                }
            }
    
            public static void DisposeUnitOfWork(IUnitOfWork unitOfWork)
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items.Remove(HTTPCONTEXTKEY);
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        _threads.Remove(Thread.CurrentThread.Name);
                    }
                }
            }
    
    
        public interface IUnitOfWork : IDisposable
            {
                void Commit();
                bool IsDisposed { get; }
            }
    
    public class UnitOfWork : MyContext
        {
            
        }
    
        public abstract class Repository<T> : IRepository<T>, IDisposable where T : class
        {
            private UnitOfWork _context;
    
            private UnitOfWork Context
            {
                get
                {
                    if (_context == null || _context.IsDisposed)
                        return _context = GetCurrentUnitOfWork<UnitOfWork>();
                    
                    return _context;
                }
            }
    
            public TUnitOfWork GetCurrentUnitOfWork<TUnitOfWork>() where TUnitOfWork : IUnitOfWork
            {
                return (TUnitOfWork)UnitOfWorkFactory.GetUnitOfWork();
            }
    
            public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
            {
                return Context.Set<T>().Where(predicate).ToList();
            }
    
            public bool Exists(Expression<Func<T, bool>> predicate)
            {
                return Context.Set<T>().Any(predicate);
            }
    
            public T First(Expression<Func<T, bool>> predicate)
            {
                return Context.Set<T>().Where(predicate).FirstOrDefault();
            }
    
            public IEnumerable<T> GetAll()
            {
                return Context.Set<T>().ToList();
            }
    
            public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
            {
                return Context.Set<T>().OrderBy(keySelector).ToList();
            }
    
            public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
            {
                return Context.Set<T>().OrderByDescending(keySelector).ToList();
            }
    
            public void Commit()
            {
                Context.SaveChanges();
            }
    
            public void Add(T entity)
            {
                Context.Set<T>().Add(entity);
            }
    
            public void Update(T entity)
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
    
            public void Delete(T entity)
            {
                Context.Set<T>().Remove(entity);
            }
    
            public void Dispose()
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
                GC.SuppressFinalize(this);
            }
        }
    
        public class MyContext : DbContext, IUnitOfWork
            {
                public DbSet<Car> Cars { get; set; }
                
                public void Commit()
                {
                    SaveChanges();
                }
        
                protected override void Dispose(bool disposing)
                {
                    IsDisposed = true;
                    UnitOfWorkFactory.DisposeUnitOfWork(this);
                    base.Dispose(disposing);
                }
        
                public bool IsDisposed { get; private set; }
            }
