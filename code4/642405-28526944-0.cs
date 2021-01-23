    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    class GoogleSuggest
    {
        static void Main(string[] args)
        {
            // driver initialization varies across different drivers
            // but they all support parameter-less constructors
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");
            query.Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });
            System.Console.WriteLine("Page title is: " + driver.Title);
            driver.Quit();
        }
    }
