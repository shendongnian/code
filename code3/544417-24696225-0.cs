    [TestClass]
    public class IntegrationTests
    {
        private static Application application = new Application() { ShutdownMode= ShutdownMode.OnExplicitShutdown };
        ~IntegrationTests()
        {
            application.Shutdown();
        }
        
        [TestMethod]
        public void MyTest()
        {
            //test
        }
    }
