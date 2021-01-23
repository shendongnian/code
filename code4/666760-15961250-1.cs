    class TopPage {
        TopPage(IWebDriver driver) {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "ul.elements li")]
        public IList<IWebElement> MyElements;
    }
