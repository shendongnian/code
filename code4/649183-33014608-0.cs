    public void main ()
    {
      driver.SwitchTo().Frame("description-editor_ifr");
      IWebElement element = _WebDriver.FindElement(By.CssSelector("body"));
      element.Clear();
      element.SendKeys("Hello");
      //Go back to main frame
      driver.SwitchTo().ParentFrame();
    }
