    [WebService(Namespace = "http://..")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
     public class MyWebService : System.Web.Services.WebService
    {
        public transactionInfo Header  { get; set; }
        ...
