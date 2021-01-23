    public class RolesAuthenticationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SiteMap.CurrentNode == null)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
