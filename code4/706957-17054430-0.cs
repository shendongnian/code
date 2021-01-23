    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    namespace SOTest {
    	[TestClass]
    	public class TestCLEditor {
    		[TestMethod]
    		public void TestMethod1() {
    			IWebDriver driver = new FirefoxDriver();
    			driver.Navigate().GoToUrl("http://premiumsoftware.net/CLEditor");
    
    			// find frames by src like 'javascript:true;' is really not a good idea, but works in this case
    			IWebElement iframe = driver.FindElement(By.XPath("//iframe[@src='javascript:true;']"));
    			driver.SwitchTo().Frame(iframe);
    
    			IWebElement body = driver.FindElement(By.TagName("body")); // then you find the body
    			body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
    			body.SendKeys("Some text");
    
    			// alternative way to send keys to body
    			// IJavaScriptExecutor jsExecutor = driver as IJavaScriptExecutor;
    			// jsExecutor.ExecuteScript("var body = document.getElementsByTagName('body')[0]; body.innerHTML = 'Some text';");
    			driver.Quit();
    		}
    	}
    }
