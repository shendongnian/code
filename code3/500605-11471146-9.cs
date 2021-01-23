    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
    
            var cookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return false;
            }
    
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var id = Guid.Parse(ticket.UserData);
            var identity = new GenericIdentity(ticket.Name);
            httpContext.User = new MyUser(identity, null)
            {
                Id = id
            };
            return true;
        }
    }
