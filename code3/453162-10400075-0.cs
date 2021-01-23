        //This class does not have a namespace on purpose, do not add one.
      [SetUpFixture]
      public class AssemblySetupFixture
      {
        [SetUp]
        public void SetupTestSuite()
        {
            Debug.WriteLine("Setting up Test Assembly Fixture");
         // Kill all web server instances and then restart them
            WebServerHelper.StopAll(); 
            WebServerHelper.StartAll();
           DatabaseHelper.RestoreDefaultDatabases();
         }
    
        [TearDown]
        public void TearDownTestSuite()
        {
            Debug.WriteLine("Tearing down Assembly Fixture");
            WebServerHelper.StopAll();
        }
      }
