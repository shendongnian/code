    using System.Web;
    using System.Web.Mvc;
    
    public class AuthorizeUser : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var id = filterContext.RequestContext.HttpContext.User.Identity;
        }
    }
