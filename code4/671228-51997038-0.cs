    public interface IUnitOfWork1 : IDisposable
    {
        T GetRepository<T>() where T : class;
        void Save();
    }
    public class UnitOfWork1 : IUnitOfWork1
    {
        private TSRModel1 db;
        public UnitOfWork1() :  this(new TSRModel1()) { }
        public UnitOfWork1(TSRModel1 dbContext)
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
    public class OrganizationRepositoryFake : GenericRepository1<Organization>, IOrganizationRepository
    {
        public OrganizationRepositoryFake(TSRModel1 db)
           : base(db)
        {
        }
    }
    public class OrganizationManager1: IOrganizationManager
    {
        private IUnitOfWork1 unitOfWork;
        private IOrganizationRepository organizationRepository;
        public OrganizationManager1(IUnitOfWork1 unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            organizationRepository = unitOfWork.GetRepository<OrganizationRepositoryFake>();
        }
        
    }
