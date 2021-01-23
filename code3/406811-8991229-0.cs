    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    class GoogleSuggest
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");
            System.Console.WriteLine("Page title is: " + driver.Title);
            driver.Quit();
        }
    }
