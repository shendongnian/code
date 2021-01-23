    [TestClass]
    public class TestClass
    {
        public TestContext TestContext { get; set; }
        
        [TestInitialize]
        public void Initialize()
        {
            Console.WriteLine(TestContext.TestName);
        }
    
        // ... Your Test methods here
    }
