    [TestClass]
    public class CustomCounter
    {
        private static PerformanceCounter CustomCounter;
        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            CustomCounter= new PerformanceCounter("CustomCounterCategory", "CustomCounter", TestContext.TestName, false);
            
            CustomCounter.BeginInit();
            CustomCounter.RawValue = 0;
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            RequestDelayCounter.RawValue = 0;
            RequestDelayCounter.EndInit();
            RequestDelayCounter.Dispose();
        }
        [TestMethod]
        public void TestCustomCounter()
        {
            Stopwatch testTimer = new Stopwatch();
            testTimer.Start();
            httpClient.SendRequest();
            testTimer.Stop();
            double requestDelay = testTimer.Elapsed.TotalMilliseconds;
            CustomCounter.RawValue = Convert.ToInt64(requestDelay);
            CustomCounter.IncrementBy(Convert.ToInt64(requestDelay));
         }
    }
