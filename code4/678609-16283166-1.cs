    public static void WaitForElementToNotExist(string ID, IWebDriver driver)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until<bool>((d) =>
        {
            try
            {
                // If the find succeeds, the element exists, and
                // we want the element to *not* exist, so we want
                // to return true when the find throws an exception.
                IWebElement element = d.FindElement(By.Id(ID));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        });
    }
