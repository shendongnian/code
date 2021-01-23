    [TestClass]
    public class UnitTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                TestContext.AddResultFile(testPassedFile);
            else
                TestContext.AddResultFile(testFailedFile);
        }
        [TestMethod]
        public void TestMethod()
        {
            
        }
        public TestContext TestContext { get; set; }
    }
