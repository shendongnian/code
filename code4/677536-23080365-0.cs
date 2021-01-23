    public class CastleProxyHandleSecurityAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ISecurityHandler securityHandler;
        public CastleProxyHandleSecurityAttribute()
        {
            securityHandler = new SecurityHandler();
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            if (controllerName.StartsWith("Castle") && filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.BaseType != null)
            {
                controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.BaseType.FullName;
            }
            var securityContext = SecurityContext.Current;
            securityContext.Data.RouteValues = filterContext.RouteData.Values;
            var overrideResult = securityHandler.HandleSecurityFor(controllerName, actionName, securityContext);
            if (overrideResult != null) filterContext.Result = overrideResult;
        }
    }
