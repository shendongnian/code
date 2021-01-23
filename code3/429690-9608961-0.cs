    [SetUpFixture]
    public class TestsInitializer
    {
        [SetUp]
        public void InitializeLogger()
        {
            XmlConfigurator.ConfigureAndWatch();
        }
    }
