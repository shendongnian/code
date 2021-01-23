    class MyAsyncClass
    {
    static IWebDriver driver;
    public static void MyAsyncMethod()
    {
     FirefoxProfile myProfile = new FirefoxProfile();
     driver = new FirefoxDriver(myProfile);
     driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
     
     STAClipBoard(myStringWithHtmlCode);
     driver.FindElement(By.Id("myTxtBoxId")).SendKeys(OpenQA.Selenium.Keys.LeftControl + "v"); 
    }
        
     private static void STAClipBoard(string myStringWithHtmlCode)
     {
         ClipClass clipClass = new ClipClass();
         clipClass.myString = myString;
         System.Threading.Thread t = new System.Threading.Thread(clipClass.CopyToClipBoard);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }//class
    public class ClipClass
    {
        public string myString;
        public void CopyToClipBoard()
        {
            Clipboard.SetText(description);
        }
    }
}
