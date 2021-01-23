    protected void Button1_Click(object sender, EventArgs e)         
    {
        IWebDriver driver = 
            new InternetExplorerDriver(@"C:\.....\IEDriverServer_Win32_2.25.2"); 
        driver.Navigate().GoToUrl("https://website.com/login.asp");
        // Find the text input element by its name
        // username
        IWebElement name_ID = driver.FindElement(By.Name("name_ID"));
        name_ID.SendKeys("xyzw");
        // password
        IWebElement pwd_PW = driver.FindElement(By.Name("pwd_PW"));
        pwd_PW.SendKeys("fasdfasfdasdf");
        // submit login form
        IWebElement sSubmit = driver.FindElement(By.Name("submit"));
        submit.Submit();
        System.Threading.Thread.Sleep(5000);
        driver.Quit();
    }
