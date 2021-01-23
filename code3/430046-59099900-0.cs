    public class(IWebDriver driver)
    {           
    this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
    wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver,TimeSpan.FromMinutes(1));
     }
    public void class1()
    {  
    wait.Until(ExpectedConditions.ElementToBeClickable(elem)).Click();
    }
