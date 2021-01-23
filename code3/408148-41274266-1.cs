    using (IWebDriver driver = new ChromeDriver(options))
            {
                TimeSpan t = new TimeSpan(10);
                WebDriverWait wait = new WebDriverWait(driver,t);
                try
                {  
                    driver.Navigate().GoToUrl("URL");
                    //IWebElement username = driver.FindElement(By.Name("loginfmt"));
                    IWebElement username = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("loginfmt")));                                      
                    username.SendKeys(dictionaryItem);
                    //Thread.Sleep(10000);
                    IWebElement next = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                    //IWebElement nextdriver.FindElement(By.Id("idSIButton9"));
                    next.Click();
