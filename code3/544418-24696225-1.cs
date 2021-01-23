    [TestClass]
    public class MockAppTests
    {
        private static Application application = new Application() { ShutdownMode= ShutdownMode.OnExplicitShutdown };
    }
    [TestClass]
    public class IntegrationTests : MockAppTests
    {        
        [TestMethod]
        public void MyTest()
        {
            //test
        }
    }
