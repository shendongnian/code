    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    
    namespace AutomatedTests.Extensions
    {
    	public static class WebElementExtensions
    	{
    		public static void SelectBySubText(this SelectElement me, string subText)
    		{
    			foreach (var option in me.Options.Where(option => option.Text.Contains(subText)))
    			{
    				option.Click();
    				return;
    			}
    			me.SelectByText(subText);
    		}
    	}
