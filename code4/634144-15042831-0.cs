    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);            
            if (!isAuthorized)
                return false;
    
            string username = httpContext.User.Identity.Name;
    
            UserRepository repo = new UserRepository();
    
            return repo.IsUserInRole(username, this.Roles);
        }
    }
