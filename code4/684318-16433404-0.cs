    public class InternalAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if(actionContext == null)
                throw new ArgumentNullException("actionContext");
            if (AuthorizationDisabled(actionContext)
                || AuthorizeRequest(actionContext))
                return;
            base.OnAuthorization(actionContext);
        }
        private static bool AuthorizationDisabled(HttpActionContext actionContext)
        {
            //support AllowAnonymousAttribute
            if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return actionContext.ControllerContext
                    .ControllerDescriptor
                    .GetCustomAttributes<AllowAnonymousAttribute>().Any();
            else
                return true;
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
