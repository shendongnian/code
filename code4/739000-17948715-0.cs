    public class MyService : System.Web.Services.WebService
    {
        public MyService()
        {
        }
        
        [WebMethod]
        public string Hello()
        {
            return "hello, my name is " + User.Identity.Name;
        }
    }
