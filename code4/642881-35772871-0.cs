    public static IWebElement WaitForElementVisible(By selector, uint timeout = Config.DefaultTimeoutSec)
        {
            IWebDriver driver = Browser.Instance.Driver;
            if (timeout > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(selector));
                return driver.FindElement(selector);
            }
            else
            {
                // Search for element without timeout 
                return driver.FindElement(selector);
            }
        }
