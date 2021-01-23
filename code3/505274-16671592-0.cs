    public static IWebDriver WebDriver;
    void Main()
    {
    	url = "...";
        var capabilitiesInternet = new OpenQA.Selenium.Remote.DesiredCapabilities();
        capabilitiesInternet.SetCapability("ignoreProtectedModeSettings", true);
    	IWebDriver driver = new InternetExplorerDriver(Path.GetDirectoryName (Util.CurrentQueryPath));
    	
    	// Navigate to url
    	driver.Navigate().GoToUrl(url);
    	
    	// Login
    	driver.FindElement(By.Name("login")).SendKeys("...");
        driver.FindElement(By.Name("password")).SendKeys("...");
        driver.FindElement(By.ClassName("button")).Click();
