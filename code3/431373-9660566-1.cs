     [TestFixture]
    public class PerTest
    {
        public PerTest(){}
        /// <summary>
        /// Setup class - runs once per class
        /// </summary>
        [TestFixtureSetUp]
        public void SetupClass()
        {
            // NOOP
        }
        /// <summary>
        /// Tear down class (cleanup)
        /// </summary>
        [TestFixtureTearDown]
        public void TearDownClass()
        {
            // NOOP
        }
        [Test, Description("Testing doing something with files on the filesystem")]
        public void MyFileSystemTest()
        {
            using (FileSandbox sandbox = new FileSandbox())
            {
                // Getting Temp file name to use
                string tempfile = sandbox.GetTempFileName("txt");
                // Get the current executing assembly (in this case it's the test dll)
                Assembly myassembly = Assembly.GetExecutingAssembly();
                // Get the stream (embedded resource) - be sure to wrap in a using block
                using (Stream stream = myassembly.GetManifestResourceStream("TestClass.TestFiles.TextFile1.txt"))
                {
                    // In this case using an external method to write the stream to the file system
                    tempfile = TestHelper.StreamToFile(stream, tempfile);
                    string[] lines = File.ReadAllLines(tempfile);
                    Assert.IsTrue(lines.Length > 0);
                }
            }
        }
    }
 
