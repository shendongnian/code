    class RepositoryFactory : IRepositoryFactory
    {
        DbContext _dbc;
        public RepositoryFactory(DbContext db)
        {
           _dbc = db;
        }
        public IRepository CreateRepository()
        {
            return new Repository(_dbc);
        }
    }
