    public static class RemoteWebDriverExtensions
    {
        public static bool ElementDoesNotExist(this RemoteWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
