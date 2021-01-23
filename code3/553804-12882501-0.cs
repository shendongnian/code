    namespace WebApiTest
    {
        public class Auth : System.Web.Http.AuthorizeAttribute
        {
            protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                return false;
            }
    
        }
    }
