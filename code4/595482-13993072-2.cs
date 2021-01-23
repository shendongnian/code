    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        public AdminOnlyAttribute()
        {
        }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!User not in Admin table)
            {
              throw new UnauthorizedAccessException();
            }
            base.OnAuthorization(filterContext);
        }
    }
