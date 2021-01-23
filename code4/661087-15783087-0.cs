    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext TestContext)
        {
            // call the base AssemblyInitialize
            BaseTestProject.BaseTest.AssemblyInitialize(TestContext);
        }
        public TestContext TestContext { get; set; }
    }
