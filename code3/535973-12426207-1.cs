	using (IWebDriver driver = new InternetExplorerDriver())
	{
		driver.Navigate().GoToUrl("https://gmail.com");
		IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2.00));
		wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
		driver.FindElement(By.Id("Email")).SendKeys("mysample.com");
		wait.Until(ExpectedConditions.ElementExists(By.Id("Passwd")));
		driver.FindElement(By.Id("Passwd")).SendKeys("password");
		driver.FindElement(By.Id("signIn")).Click();
	} 
