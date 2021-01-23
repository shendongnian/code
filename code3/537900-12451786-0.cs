    // WARNING: Untested code written from memory. 
    // Not guaranteed to be exactly correct.
    List<string> matchingLinks = new List<string>();
    // Assume "driver" is a valid IWebDriver.
    ReadOnlyCollection<IWebElement> links = driver.FindElements(By.TagName("a"));
    // You could probably use LINQ to simplify this, but here is
    // the foreach solution
    foreach(IWebElement link in links)
    {
        string text = link.Text;
        if (Regex.IsMatch("your Regex here", text))
        {
            matchingLinks.Add(text);
        }
    }
    foreach(string linkText in matchingLinks)
    {
        IWebElement element = driver.FindElement(By.LinkText(linkText));
        element.Click();
        // do stuff on the page navigated to
        driver.Navigate().Back();
    }
