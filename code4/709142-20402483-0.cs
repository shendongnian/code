       namespace UnitTestProject1_webdriver
    {
	
	public class ChromeOptionsWithPrefs : ChromeOptions
	{
		public Dictionary<string, object> prefs { get; set; }
	}
	[TestClass]
	public class demo
	 {
		[TestMethod]
		public void demo1()
		{var options = new ChromeOptionsWithPrefs();
			options.prefs = new Dictionary<string, object>
			{
				{ "download.default_directory", @"c:\download temp\" }
			};
			RemoteWebDriver driver = new ChromeDriver(@"d:\selenium dlls\", options);
        }
     }
 
    }
    
 
