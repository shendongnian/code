    public class TokenAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.AbsolutePath.Contains("api/auth"))
            {
                return;
            }
    
            var authManager = new AuthCacheManager();
    
            var user = authManager.CurrentUser;
    
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
    
            //Updates the authentication
            authManager.Authenticate(user.SocialUser);
        }
    }
