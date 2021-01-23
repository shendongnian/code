    // in the dll:
    public class BaseAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute { ... }
    
    // in the web project:
    public class InternalAuthorizeV2Attribute : BaseAuthorizeAttribute { ... }
