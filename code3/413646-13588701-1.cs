    try
    {
        System.Drawing.Point point = ((OpenQA.Selenium.Remote.RemoteWebElement)Driver.FindElement(By.XPath(sLocator))).LocationOnScreenOnceScrolledIntoView;
    }
    catch (Exception)
    {}
