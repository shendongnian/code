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
            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadAbortException e)
            {
                 Assert.Fail((string)e.ExceptionState);
            }
        }
        private void abortIfTestStilRunsAfterTimeout()
        {
            testThread.Abort("timeout passed!");
        }
    }
