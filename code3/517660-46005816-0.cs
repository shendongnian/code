    //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20)); // waits 10 seconds
            driver.FindElement(By.XPath("//div[@class='sign-in-dialog-provider']")).Click(); // directed to sign in using Google account
            driver.FindElement(By.Id("identifierId")).SendKeys("YOUR Email\n"); // enter gmail account and press Enter by using \n
          
            Thread.Sleep(10); // just to wait page loading
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20)); // just to wait page loading
            //driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys("1234ziad\n");
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            // to go and focus to password text field !!!
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input"))).Build().Perform();
            // below lines to wait untill invisible elements being visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement checkOut = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")));
            // to send the password
            checkOut.SendKeys("Your Password");
            // to click next ......... I got all this XPath using Chrome after clicking on Inspect then right click the highlighted item and click on copy XPath
            // and use it in below line to click Next and login
            driver.FindElement(By.XPath("//*[@id='passwordNext']/content")).Click();
