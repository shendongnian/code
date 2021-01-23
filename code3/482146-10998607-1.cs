    [TestClass]
    public class UnitTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome.ToString().Equals("Failed"))
                TestContext.AddResultFile(testFailedFile);
            else
                TestContext.AddResultFile(testPassedFile);
        }
        [TestMethod]
        public void TestMethod()
        {
            
        }
        public TestContext TestContext { get; set; }
    }
