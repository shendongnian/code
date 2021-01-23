    [FindsBy(How = How.ClassName, Using = "select2-arrow")]
    private IWebElement Selector { get; set; }
    private void selectItem(string itemText)
    {
        Selector.Click();  // open the drop
        var drop = Driver.FindElement(By.Id("select2-drop"));    // exists when open only
        var item = drop.FindElement(By.XPath(String.Format("//li[contains(translate(., '{0}', '{1}'), '{1}')]", itemText.ToUpper(), itemText.ToLower())));
        item.Click();
    }
