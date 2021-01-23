    [TestClass]
    public class TestClass
    {
        [TestCleanup]
        public void TestCleanup()
        {
            // here you have access to the CurrentTestOutcome bot not on stacktrace
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                // do something
            }
        }
        [TestMethod]
        public void TestMethod()
        {
            try
            {
                // Your test code here
            }
            catch (Exception exception)
            {
                // here you have access to the StackTrace
                TestContext.WriteLine(exception.StackTrace);
                // You can also add it to the TestContext and have access to it from TestCleanup
                TestContext.Properties.Add("StackTrace", exception.StackTrace);
                // Or...
                TestContext.Properties.Add("Exception", exception);
                throw;
            }
        }
    }
