    [TestClass]
    public class SomeTestClass
    {
        Thread testThread;
        [TestInitialize]
        public void BeforeTest()
        {
            testThread = Thread.CurrentThread;
            var task = new Task(abortIfTestStilRunsAfterTimeout);
            task.Start();
        }
        [TestMethod]
        public void TestMethod()
        {
            Thread.Sleep(5000);
        }
        private void abortIfTestStilRunsAfterTimeout()
        {
            testThread.Abort();
        }
    }
