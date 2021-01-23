    [TestFixture]
    class MyTestFixture
    {
        protected IWebDriver driver;
        protected IWebElement name;
        protected IWebElement button;
        
        [TestFixtureSetUp]
        public void Init()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(urlString);
            name = driver.FindElement(By.Id("UserName"));
            button = driver.FindElement(By.ClassName("sign in"));
        }
        
        [Test]
        public void MyTest
        {
         // ...
        }
    }
