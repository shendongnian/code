    public static void WaitForElementInvisible(string ID, IWebDriver driver)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until<bool>((d) =>
        {
            try
            {
                IWebElement element = d.FindElement(By.Id(ID));
                return !element.Displayed;
            }
            catch (NoSuchElementException)
            {
                // If the find fails, the element exists, and
                // by definition, cannot then be visible.
                return true;
            }
        });
    }
