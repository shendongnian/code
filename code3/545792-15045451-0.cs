    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium;
    using System.Collections.Specialized;
    
    enum Browser { ie, firefox, chrome };
    
    
    namespace SearchandClickAds
    {
        class Program
        {
    
    
            public static RemoteWebDriver getRemoteDriver(Browser b)
            {
    
                switch (b)
                {
                    case Browser.ie:
                        return new InternetExplorerDriver(
                                        InternetExplorerDriverService.CreateDefaultService(),
                                        new InternetExplorerOptions(),
                                        TimeSpan.FromMinutes(10)
                        );
    
                    case Browser.firefox:
    
                        return new FirefoxDriver(
                                    new FirefoxBinary(),
                                    new FirefoxProfile(),
                                    TimeSpan.FromMinutes(10)
                        );
    
                    case Browser.chrome:
    
                        return new ChromeDriver(
                                                    ChromeDriverService.CreateDefaultService(),
                                                    new ChromeOptions(),
                                                    TimeSpan.FromMinutes(10)
                        );
                }
    
                return null;
            }
    
    
            static void Main(string[] args)
            {
    
                string browser_s = args[0].ToLower();
                Browser browser;
    
                if (browser_s == "ie")
                {
                    browser = Browser.ie;
                }
                else if (browser_s == "chrome")
                {
                    browser = Browser.chrome;
                }
                else if (browser_s == "firefox")
                {
                    browser = Browser.firefox;
                }
                else
                {
                    Console.WriteLine("Unknown browser. Must be ie, chrome, or firefox");
                    return;
                }
    
                RemoteWebDriver driver = null;
    
                while (true)
                {
                    try
                    {
    
                        driver = getRemoteDriver(browser);
                        /* Do navigation here */
                     }
                }
                            
                Console.WriteLine("Done.");
                Environment.Exit(0);
                return;
    
            }
        }
    }
