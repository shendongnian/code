    /// <summary>
    /// Requires HTTPS connection unless running under Visual Studio debugger.
    /// </summary>
    public class RemoteRequireHttpsAttribute : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null 
                && filterContext.HttpContext != null 
                && filterContext.HttpContext.Request.IsLocal)
                return;
            base.OnAuthorization(filterContext);
        }
    }
