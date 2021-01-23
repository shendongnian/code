        IWebElement searchBox = this.WebDriver.FindElement(By.Id("searchEntry"));
    searchBox.SendKeys(searchPhrase);
    System.Threading.Thread.Sleep(3000);
    
    IList<IWebElement> results = this.WebDriver.FindElements(By.CssSelector(".tt-suggestion.tt-selectable"));
    if (results.Count > 1)
    {
    
        searchResult = results[1].FindElement(By.TagName("span")).GetAttribute("textContent");
    }
