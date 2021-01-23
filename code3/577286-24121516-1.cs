        protected Tuple<bool, string> waitForEitherElementText(By locator1, string expectedText1, string return1Ident,
            By locator2, string expectedText2, string return2Ident, IWebDriver driver, int retries)
        {
            var retryCount = 0;
            string returnText = "";
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(globalWaitTime));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0.5));
            while (retryCount < retries)
            {
                try
                {
                    explicitWait.Until<bool>((d) =>
                    {
                        try
                        {
                            if (Equals(d.FindElement(locator1).Text, expectedText1)) { returnText = return1Ident; };
                        }
                        catch (NoSuchElementException)
                        {
                            if (Equals(d.FindElement(locator2).Text, expectedText2)) { returnText = return2Ident; };
                        }
                        return (returnText != "");
                    });
                    return Tuple.Create(true, returnText);
                }
                catch (StaleElementReferenceException e)
                {
                    Console.Out.WriteLine(DateTime.UtcNow.ToLocalTime().ToString() +
                        ":>>> -" + locator1.ToString() + " OR " + locator2.ToString() + "- <<< - " +
                        this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name +
                        " : " + e.Message);
                    retryCount++;
                }
            }
            return Tuple.Create(false,"");
        }
