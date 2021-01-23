    [TestClass]
    public class TestClass
    {
        [TestInitialize]
        public void Initialize()
        {
            switch (TestContext.TestName)
            {
                case "TestMethod1":
                    this.InitializeTestMethod1();
                    break;
                case "TestMethod2":
                    this.InitializeTestMethod2();
                    break;
                default:
                    break;
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestMethod2()
        {
        }
        private void InitializeTestMethod1()
        {
            // Initialize TestMethod1
        }
        private void InitializeTestMethod2()
        {
            // Initialize TestMethod2
        }
        public TestContext TestContext { get; set; }
    }
