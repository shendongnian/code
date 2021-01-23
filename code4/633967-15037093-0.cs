    <code>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    //Need to add these two libarary
    //For that u need to have WebDriver.dll and WebDriver.Support.dll 
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    
    namespace Test
    {
    class Program
    {
    static void Main(string[] args)
    {
    //Intializing the webdriver. 
    //Note i m using firefox driver, others can also be used.
    IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
    //Navigating to the given page.
    driver.Navigate().GoToUrl("url of the page you want to get the option from");
    //Finding the element. If element not present it throws exception so do remember to handle it.
    var element = driver.FindElement(By.Id("ctl00_BodyContent_ddlChooseView"));
    //No intializing the select element option.
    SelectElement selectElem = new SelectElement(element);
    selectElem.SelectByValue("H"); 
    //or i can select option using text that is
    selectElem.SelectByText("Option1"); 
    }
    
    }
    }
    </code>
