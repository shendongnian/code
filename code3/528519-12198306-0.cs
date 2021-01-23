    [TestClass]
    public class TestClass
    {
        [TestInitialize]
        public void TestIntialize()
        {
            string testMethodName = TestContext.TestName;
        }
    
        [TestMethod]
        public void TestMethod()
        {
        }
    
        public TestContext TestContext { get; set; }
    }
