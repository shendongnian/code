    [TestClass]
    public class MyTestClass
    {
        public TestContext TestContext { get; set; }
        
        [TestInitialize]
        public void setup()
        {
            logger.Info(" SETUP " + TestContext.TestName);
            // .... //
        }
    }
