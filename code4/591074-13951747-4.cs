    public class EntityFrameworkIntegrationTest
    {
        protected MyDbContext DbContext;
    
        protected TransactionScope TransactionScope;
    
        [TestInitialize]
        public void TestSetup()
        {
            DbContext = new MyDbContext(TestInit.TestDatabaseName);
            DbContext.Database.CreateIfNotExists();
            TransactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }
    
        [TestCleanup]
        public void TestCleanup()
        {
            TransactionScope.Dispose();
        }
    }
