    [TestClass]
    public class SomeTests
    {
        public TestContext TestContext { get; set; }
    
        [TestMethod]
        public void ATest()
        {
            string currentDirectory = TestContext.DeploymentDirectory;
            ...
        }
    }
