    public class SessionValidationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {
                bool canAccess = true; // replace this with access logic!
                if (!canAccess)
                    filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public abstract bool CanAccessResource(User user);
    }
