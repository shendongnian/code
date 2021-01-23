    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld(int? x)
        {
            return "Hello World";
        }
    }
