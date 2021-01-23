    [TestClass]
        public class IntegrationTests
        {
            private CedarFile testCedarFile;
    
            /// <summary>
            /// This test tests methods that utilize Application.Current. 
            /// They all have to be in the same test because they must run on the same thread to use the Application instance.
            /// </summary>
            [TestMethod]
            public void IntegrationTests_All()
            {
                new Application();
    
                QualifierViewModel_FlagsAndLoadDatasets();
                CurrentFilesViewModel_AddCedarFile();
                CurrentFilesViewModel_AddCedarFileReadOnly();
            }
    ... the private methods to test ...
    }
