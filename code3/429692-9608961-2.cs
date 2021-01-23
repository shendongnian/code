    [SetUpFixture]
    public class TestsInitializer
    {
        [SetUp]
        public void InitializeLogger()
        {
            LoggingFacility.InitLogger();
        }
    }
