    public class MyWebService: System.Web.Services.WebService
    {
        public static string test = String.Empty;
        public string GetTest() {
          return test;
        }
        public void SetTest(string test) {
          MyWebService.test = test;
        }
    }
