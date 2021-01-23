    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    // Requires reference to WebDriver.Support.dll
    using OpenQA.Selenium.Support.UI;
    
    class RedirectThenReadUrl
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Firefox driver.
    
            // Notice that the remainder of the code relies on the interface, 
            // not the implementation.
    
            // Further note that other drivers (InternetExplorerDriver,
            // ChromeDriver, etc.) will require further configuration 
            // before this example will work. See the wiki pages for the
            // individual drivers at http://code.google.com/p/selenium/wiki
            // for further information.
            IWebDriver driver = new FirefoxDriver();
    
            //Notice navigation is slightly different than the Java version
            //This is because 'get' is a keyword in C#
            driver.Navigate().GoToUrl("http://www.google.com/");
    
            // Print the original URL
            System.Console.WriteLine("Page url is: " + driver.Url);
    
            // In your case, the redirect happens here - you just have to wait for
            // the new page to load before reading the new values
    
            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Url.ToLower().Contains("cheese"); });
  
            // Print the redirected URL
            System.Console.WriteLine("Page url is: " + driver.Url);
    
            // Should see: "Cheese - Google Search"
            System.Console.WriteLine("Page title is: " + driver.Title);
    
            //Close the browser
            driver.Quit();
        }
    }
