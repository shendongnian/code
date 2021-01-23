    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // call the base AssemblyInitialize
            BaseTestProject.BaseTest.AssemblyInitialize(testContext);
        }
        public TestContext TestContext { get; set; }
    }
