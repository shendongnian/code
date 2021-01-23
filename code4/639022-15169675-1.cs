    private TransactionScope _transactionScope;
            private Repository _repository;
            private ProjectDataSource _dataSource; 
            private const string _connectionString = "Data Source=.;Initial Catalog=test_db;Trusted_Connection=True";
    
            [TestInitialize]
            public virtual void TestInitialize()
            {
                _repository = new Repository(_connectionString);
                _dataSource = new ProjectDataSource(_connectionString);
                _dataSource.Database.Delete();
                _dataSource.Database.CreateIfNotExists();
                _transactionScope = new TransactionScope();
            }
