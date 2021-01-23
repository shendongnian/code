    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void Method1(int x)
        {
            // i'm good
        }
        [WebMethod]
        public string Method2(int? x)
        {
            return "it worked";
        }
    }
