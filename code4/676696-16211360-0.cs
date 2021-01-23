    [WebService(Namespace=http://yournamespace/")]
    public class PageReferenceService : System.Web.Services.WebService
    { 
        [WebMethod()]
        public PageReference GetDynamicProperty(PageReference rootNode, string propertyName)
        {
            return DynamicProperty.Load(rootNode, propertyName);
        }  
    }
