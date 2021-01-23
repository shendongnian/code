    [TestClass]
    public class UnitTest1
    {
        PerformanceCounter RequestDelayTime;
        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            // Create the instances of the counters for the current test
            RequestDelaytime = new PerformanceCounter("CustomCounterSet", "RequestDelayTime", "UnitTest1", false));
            // .... Add the rest counters instances
        }
        [TestCleanup]
        public void CleanUp()
        {
            RequestDelayTime.RawValue = 0;
            RequestDelayTime.EndInit();
            RequestDelayTime.RemoveInstance();
            RequestDelayTime.Dispose();
        }
        [TestMethod]
        public void TestMethod1()
        {
             // ... Testing
             // update counters
             RequestDelayTime.Incerement(time);
             // ... Continue Testing
        }
    }
