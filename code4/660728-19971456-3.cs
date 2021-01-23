    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld(int? x)
        {
            if (x != null)
            {
                return x.ToString();
            }
            return "Hello World";
        }
        [WebMethod]
        public void voidMethod(int x)
        {
          
        }
    }
