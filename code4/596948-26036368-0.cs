    namespace MyTests
    {
        /// <summary>
        /// Summary description for AssemblyTestInit
        /// </summary>
        [TestClass]
        [DeploymentItem("EntityFramework.SqlServer.dll")]
        public class AssemblyTestInit
        {
            public AssemblyTestInit()
            {
            }
            private TestContext testContextInstance;
            public TestContext TestContext
            {
                get
                {
                    return testContextInstance;
                }
                set
                {
                    testContextInstance = value;
                }
            }
            [AssemblyInitialize()]
            public static void DbContextInitialize(TestContext testContext)
            {
                Database.SetInitializer<TestContext>(new TestContextInitializer());
            }
        }
    }
