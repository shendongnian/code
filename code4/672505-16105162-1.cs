    leagueNameItem.Click();
    IList<IWebElement> outerTables_forEachLeague = new List<IWebElement>();
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    outerTables_forEachLeague = wait.Until<IList<IWebElement>>((d) =>
    {
        var elements = d.FindElements(By.ClassName("boxVerde"));
        if (elements.Count == 0)
        {
            return null;
        }
        return elements;
    });
