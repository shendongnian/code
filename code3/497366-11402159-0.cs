    [TestFixture]
    public class WebTests
    {
        private IWebDriver driver;
        [SetUp]
        public void StartDriver()
        {
            driver = new FirefoxDriver();
        }
        [TearDown]
        public void StopDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
