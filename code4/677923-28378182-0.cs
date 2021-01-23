    [TestFixture]
    public class Driver
    {
        [Start]
        public void Start()
        {
           using (var driver = new PhantomJSDriver(@"D:\src\Tests\Drivers"))
           {
              driver.Url = "https://www.google.com";
              Assert.AreEqual("Google", driver.Title);
           }
        }
    }
