    [TestClass]
        public class UnitTest1
        {
            public TestContext TestContext
            {
                get;
                set;
            }
    
            //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ExpectedValues.xml", "Values", DataAccessMethod.Sequential)]
            //[ClassInitialize]
            //public static void ClassInitialize(TestContext testContext)
            //{
            //    string indexPath = testContext.DataRow["searchTerm2"].ToString();
            //    Console.WriteLine(indexPath);
            //}
    
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ExpectedValues.xml", "Values", DataAccessMethod.Sequential)]
            [TestInitialize]
            public void TestInitialize()
            {
                string indexPath = TestContext.DataRow["indices"].ToString();
                Console.WriteLine(indexPath);
            }
    
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ExpectedValues.xml", "Values", DataAccessMethod.Sequential)]        
            [TestMethod]
            public void TestMethod1()
            {
                string indexPath = TestContext.DataRow["pb1"].ToString();
                Console.WriteLine(indexPath);
            }
        }
