    using OpenQA.Selenium.Chrome;
    ...
    private IWebDriver chrome;
    ...
    [SetUp]
    public void SetupTest()
        {
            chrome= new ChromeDriver();
            baseURL = "url-goes-here";
            verificationErrors = new StringBuilder();
        }
    ...
