    public void TestGoogleStillExists(IWebDriver webDriver)
    {
        webDriver.Navigate().GoToUrl("http://www.google.com");
        var title = webDriver.Title;
        Assert.That(title, Is.EqualTo("Google"));
    }
