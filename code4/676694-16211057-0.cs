    [WebService(Namespace=http://yournamespace/")]
    public class PageReferenceService : System.Web.Services.WebService
    { 
        [WebMethod()]
        public PageReference GetStartPage()
        {
            return PageReference.StartPage;
        }  
    }
