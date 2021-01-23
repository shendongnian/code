    // WARNING! Untested code written from memory
    // without the aid of an IDE. Not guaranteed to
    // work or even compile without modification.
    // Use private field, public property
    // (personal choice). 
    private List<IWebDriver> activeDrivers = new List<IWebDriver>();
    public List<IWebDriver> ActiveDrivers
    {
        get { return this.activeDrivers; }
    }
    [TestFixtureSetUp]
    public void InitializeDrivers()
    {
        // Will run once for the class.
        // Use [SetUp] attribute to run
        // before each test method.
        this.activeDrivers.Add(new InternetExplorerDriver());
        this.activeDrivers.Add(new FirefoxDriver());
        this.activeDrivers.Add(new ChromeDriver());
    }
    [TestFixtureTearDown]
    public void QuitAllDrivers()
    {
        foreach(IWebDriver driver in this.activeDrivers)
        {
            driver.Quit();
        }
    }
    [TestCaseSource("ActiveDrivers")]
    public void MyTest(IWebDriver driver)
    {
        // Test goes here
    }
