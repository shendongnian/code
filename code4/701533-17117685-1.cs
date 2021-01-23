    [TestClass]
    public class UnitTest1
    {
        PerformanceCounter OverallDelay;
        PerformanceCounter PerDelay;
   
        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            // Create the instances of the counters for the current test
            // Initialize it here so it will created only once for this test class
            OverallDelay= new PerformanceCounter("MyCounters", "Delay", "Overall", false));
            PerDelay= new PerformanceCounter("MyCounters", "Delay", "Per", false));
            // .... Add the rest counters instances
        }
    
        [ClassCleanup]
        public void CleanUp()
        {
            // Reset the counters and remove the counter instances
            OverallDelay.RawValue = 0;
            OverallDelay.EndInit();
            OverallDelay.RemoveInstance();
            OverallDelay.Dispose();
            PerDelay.RawValue = 0;
            PerDelay.EndInit();
            PerDelay.RemoveInstance();
            PerDelay.Dispose();
        }
    
        [TestMethod]
        public void TestMethod1()
        {
             // Use stopwatch to keep track of the the delay
             Stopwatch overall = new Stopwatch();
             Stopwatch per = new Stopwatch();
             overall.Start();
             for (int i = 0; i < 5; i++)
             {
                 per.Start();
                 doAction();
                 per.Stop();
                 // Update the "Per" instance of the "Delay" counter for each doAction on every test
                 PerDelay.Incerement(per.ElapsedMilliseconds);
                 Sleep(1000);
             }
             overall.Stop();
             // Update the "Overall" instance of the "Delay" counter on every test
             OverallDelay.Incerement(per.ElapsedMilliseconds);
         }
    }
