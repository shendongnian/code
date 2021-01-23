        private FileSandbox _sandbox;
        private string _tempFileLocation;
        public PerEachTest() { }
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
        [SetUp]
        public void Setup()
        {
            _sandbox = new FileSandbox();
            // Getting Temp file name to use
            _tempFileLocation = _sandbox.GetTempFileName("txt");
            // Get the current executing assembly (in this case it's the test dll)
            Assembly myassembly = Assembly.GetExecutingAssembly();
            // Get the stream (embedded resource) - be sure to wrap in a using block
            using (Stream stream = myassembly.GetManifestResourceStream("TestClass.TestFiles.TextFile1.txt"))
            {
                // In this case using an external method to write the stream to the file system
                _tempFileLocation = TestHelper.StreamToFile(stream, _tempFileLocation);
            }
        }
        [TearDown]
        public void Teardown()
        {
            _sandbox.Dispose();
        }
        [Test, Description("Testing doing something with files on the filesystem")]
        public void MyFileSystemTest()
        {
            string[] lines = File.ReadAllLines(_tempFileLocation);
            Assert.IsTrue(lines.Length > 0);
        }
    }
 
 
