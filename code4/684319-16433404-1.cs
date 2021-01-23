    public class InternalAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if(actionContext == null)
                throw new ArgumentNullException("actionContext");
            if (AuthorizeRequest(actionContext))
                return;
            // no special authorization found. fall back to base (handles AllowAnonymous, and Controller level attribute)
            base.OnAuthorization(actionContext);
        }
        private bool AuthorizeRequest(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<InternalAuthorizeAttribute>().Any())
                return false;
            foreach (AuthorizeAttribute attribute in actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>())
            {
                foreach (var role in attribute.Roles.Split(','))
                {
                    if (HttpContext.Current.User.IsInRole(role)) return true;
                }
            }
            return false;
        }
    }
