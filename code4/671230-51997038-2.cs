    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class;
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private Model1 db;
        public UnitOfWork() :  this(new Model1()) { }
        public UnitOfWork(TSRModel1 dbContext)
        {
            db = dbContext;
        }
        public T GetRepository<T>() where T : class
        {          
            var result = (T)Activator.CreateInstance(typeof(T), db);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(Model1 db)
           : base(db)
        {
        }
    }
    public class TestManager: ITestManager
    {
        private IUnitOfWork unitOfWork;
        private ITestRepository testRepository;
        public TestManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            testRepository = unitOfWork.GetRepository<TestRepository>();
        }
        
    }
