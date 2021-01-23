	public class RootFrame
	{
		[FindsBy(How = How.CssSelector, Using = "#root-id")]
		private IWebElement vfrFrame;
		protected IWebDriver driver;
		public VfrElement(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}
		public void ResetMouseCursor()
		{
			new Actions(driver).MoveToElement(vfrFrame, 0, 0).Perform();
		}
	}
