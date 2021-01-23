    using (IWebDriver driver = new ChromeDriver(options))
            {
                TimeSpan t = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(driver,t);
                try
                {  
                    driver.Navigate().GoToUrl("URL");
                    //IWebElement username = driver.FindElement(By.Name("loginfmt"));
                    IWebElement username = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("loginfmt")));                                      
                    username.SendKeys(dictionaryItem);
                    //Thread.Sleep(10000); Removed my Thread.Sleep and tested my wait.Until and vola it works awesome.
                    IWebElement next = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                    //IWebElement nextdriver.FindElement(By.Id("idSIButton9"));
                    next.Click();
