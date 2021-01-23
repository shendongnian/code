    public class ApplicationRepository : Repository<YourTable>, IYourTableRepository
    {
        private YourEntities _dataContext;
        protected new IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        public YourTableRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
        protected new YourEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
       }
        public interface IYourTableRepository : IRepository<YourTable>
       {
       }
    }
