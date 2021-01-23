    selenium.SwitchTo().Frame("a");
    IList<IWebElement> dt = selenium.FindElements(By.XPath("//div[@id='b']//dt"));
    // alternative way
    selenium.SwitchTo().Frame(selenum.FindElement(By.CssSelector("frame[name='a']")));
    IList<IWebElement> dt = selenium.FindElements(By.CssSelector("#b dt"));
