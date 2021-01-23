    public WaitForElement(string el_id)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement category = wait.Until<IWebElement>((d) =>
        {
            return d.FindElement(By.Id(el_id));
        });
    }
