        private readonly ApplicationDbContext _applicationDbContext;
        string connectionString = string.Empty;
        public CommonService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            connectionString = _applicationDbContext.Database.GetDbConnection().ConnectionString;
        }
