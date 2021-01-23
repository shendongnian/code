    [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class SampleWebService : System.Web.Services.WebService
        {
    [WebMethod]
            public DateTime GetServerDate()
            {
                return DateTime.Now;
            }
        }
