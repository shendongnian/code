    public void WaitForElementById(string elementId, int timeout = 5)
    {
        WebDriverWait _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, timeout));
        IWebElement element = _wait.Until(x => x.FindElement(By.Id(elementId)));
    }
