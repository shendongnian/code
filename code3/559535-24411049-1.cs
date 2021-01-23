    [TestClass]
    [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")] // this is the key
    public class LocalStoreServiceTests
    {
        [TestMethod]
        public void SomeTestThatWasFailing_DueToThisVeryIssue()
        {
             // ... test code here
        }
    }
