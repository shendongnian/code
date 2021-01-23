    using (var browser = new IE("https://Site.com"))
    {
        var SearchDiv = browser.Div(Find.ByText("Search"));
        // Only try to click the DIV if we found it
        if(null != SearchDiv)
        {
            SearchDiv.Click();
        }
        var SearchButton = browser.Button(Find.ById("btnSearch_page"));
        // Only try to click the button if we found it
        if(null != SearchButton)
        {
            SearchButton.Click();
        }
    }
