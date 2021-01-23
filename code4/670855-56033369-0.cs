    [Given(@"I have selected the link to the OrgPlus application")]
    public void GivenIHaveSelectedTheLinkToTheOrgPlusApplication()
    {
        _driver.Navigate().GoToUrl("http://orgplus.myorg.org/ope?footer");
    }
    [Given(@"I have selected the link to the OrgPlus Directory lookup")]
    public void GivenIHaveSelectedTheLinkToTheOrgPlusDirectoryLookup()
    {
        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
        var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"lnkDir\"]")));
        IWebElement btnSearch = _driver.FindElement(By.XPath("//*[@id=\"lnkDir\"]"));
        btnSearch.SendKeys(Keys.Enter);
    }
