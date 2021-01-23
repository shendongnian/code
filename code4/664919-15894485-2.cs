    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = HttpContext.Current.Request.Headers["requestToken"];
            // Do the authorization based on token
        }
    }
