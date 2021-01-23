    [Test, TestCaseSource(typeof(WebDriverFactory), "Drivers")]
    public void SomeTest(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("...");
        ...
    }
