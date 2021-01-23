    public class MyActionFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var fooCookie = filterContext.HttpContext.Request.Cookies["foo"];
    
            if (fooCookie == null || fooCookie.Value != "foo bar")
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
