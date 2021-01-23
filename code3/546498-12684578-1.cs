    [TestClass]
    public abstract class MyTestBase 
    {
        protected abstract IMyRepository CreateRepository();
        
        [TestMethod]
        public void MyTest1()
        {
            // use IMyRepository
            // execute tests
        }
    }
    [TestClass]
    public sealed class MyUnitTest : MyTestBase
    {
        protected abstract IMyRepository CreateRepository()
        {
            IMyRepository mockedRepository = /* create a mock */;
        }
        // additional unit tests that are not dependent upon database
    }
    [TestClass]
    public sealed class MyIntegrationTest : MyTestBase
    {
        [TestSetup]
        public void TestSetup()
        {
            // configure the database to be pristine
        }
        [TestCleanup]
        public void TestCleanup()
        {
            // dispose of database connections etc.
        }
         
        protected abstract IMyRepository CreateRepository()
        {
            IMyRepository mockedRepository = /* create real repository */;
        }
    }
