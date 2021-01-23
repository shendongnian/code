    public class DevModeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authorize = base.IsAuthorized(actionContext);
            if (!authorized)
            {
                // the user is not authorized, no need to go any further
                return false;
            }
    
            // now apply your custom authorization logic here and return true or false
            ...
        }
    }
