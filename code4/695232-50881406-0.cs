    [BeforeScenario]
        public void BeforeScenario()
        {
            var name = Locale == "sauce" ? "AppiumSauceDriver" : "AppiumDriver";
            InitializeServiceLocator();
            if (WebDriver == null)
            {
                InitializeWebDriver(name);
            }
            ObjectContainer.RegisterInstanceAs(WebDriver);
            if (WebDriver != null)
            {
                Console.WriteLine("Driver Already Exists");
            }
        }
