    [TestClass]
    public class TestClass
    {
        public TestContext TestContext { get; set; }
        
        [TestInitialize]
        public void Initialize()
        {
            // Runs once before each test method and logs the method's name
            Console.WriteLine(TestContext.TestName);
        }
    
        [TestMethod]
        public void TestMethod1()
        {
            // Logs the method name inside the method
            Console.WriteLine(String.Format("In Test '{0}'", TestContext.TestName));
        }
        // ... Your rest test methods here
    }
