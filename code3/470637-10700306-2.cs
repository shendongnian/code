    [TestClass]
    public class UnitTest
    {
        public TestContext TestContext { set; get; }
    
        [TestInitialize]
        public void Initialize()
        {
            switch (TestContext.TestName)
            {
                case "TestMethod1":
                    this.IntializeTestMethod1();
                    break;
                case "TestMethod2":
                    this.IntializeTestMethod2();
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
        public void IntializeTestMethod1()
        {
            //Initialize Test Method 1
        }
        public void IntializeTestMethod2()
        {
            //Initialize Test Method 2
        }
    }
