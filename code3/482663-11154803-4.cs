    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.IE;
    
    namespace SeleniumTest
    {
       	[TestClass]
       	public class IEDriverTest
       	{
       		private const string URL = "http://url";
       		private const string IE_DRIVER_PATH = @"C:\PathTo\IEDriverServer.exe";
       
       		[TestMethod]
       		public void Test()
       		{
       			var options = new InternetExplorerOptions()
       			{
       				InitialBrowserUrl = URL,
       				IntroduceInstabilityByIgnoringProtectedModeSettings = true
       			};
       			var driver = new InternetExplorerDriver(IE_DRIVER_PATH, options);
       			driver.Navigate();
                driver.Close(); // closes browser
       			driver.Quit(); // closes IEDriverServer process
       		}
       	}
    }
