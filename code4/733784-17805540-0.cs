    [TestClass]
    public class TestCase
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "files.csv", "files#csv", DataAccessMethod.Sequential)]
        public void TestCase()
        {
            TestLogic testObj = new TestLogic();
    		
    		string source = (string) TestContext.DataRow["source"]; // get the value from the 'source' column
    		string target = (string) TestContext.DataRow["target"]; // get the value from the 'target' column
    		
    		Assert.IsTrue(testObj.VerifyFiles(source, target));
        }
    
       public TestContext TestContext{ get; set; }
    }
