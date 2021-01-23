    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using System.IO;
    namespace Automation
      {
        class To_Run_IE
         {
            static void Main(string[] args)
            {
             //Keep Internetexplorer.exe in "D:\Automation\32\Internetexplorer.exe"
              IWebDriver driver = new InternetExplorerDriver(@"D:\Automation\32\"); \\Give path till the exe folder
             //IWebDriver driver = new Firefoxdriver()
           driver.Navigate().GoToUrl("http://www.google.com/");
           driver.Manage().Window.Maximize();         
           IWebElement query = driver.FindElement(By.Name("q"));
           query.SendKeys("Cheese");		
           query.Submit();		   
           System.Console.WriteLine("Page title is: " + driver.Title);
           driver.Quit();
        }
    } }
