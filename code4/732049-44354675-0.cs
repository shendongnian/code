    protected void SelectOptionForSelect2(IWebDriver driver, string id, string text)
    {
      var element = driver.FindElement(By.Id(id)).FindElement(By.XPath("following-sibling::*[1]"));
      element.Click();
      element = driver.FindElement(By.CssSelector("input[type=search]"));
      element.SendKeys(text);
      Thread.Sleep(1000);
      element.SendKeys(Keys.Enter);
    }
