    [TestClass]
    public class MyTests {
        static bool _testFailed;
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // Create database!
            _testFailed = false;
        }
        
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            if(_testFailed == false) {
            // Remove database IF CurrentTestOutcome == UnitTestOutcome.Passed
            }
        }
        [TestCleanup()]
        public void MyTestCleanup() {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed) {
                _testFailed = true;
            }
        }
        public TestContext TestContext { get; set; }
    }
