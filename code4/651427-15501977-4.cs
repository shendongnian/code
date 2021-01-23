    [TestFixture]
    public class WithDatabaseContext
    {
        private string dbLocation;
        private BaseDataContextFactory dataContextFactory
        
        protected BaseDataContextFactory DataContextFactory
        {
            get { return this.dataContextFactory; }
        }
        [TestFixtureSetUp]
        public void FixtureInit()
        {
            // Initialize dbLocation
            // Initialize dataContextFactory
        }
    
        [TestFixtureTearDown]
        public void FixtureDispose()
        {
            // Delete file at dbLocation
        } 
    }
