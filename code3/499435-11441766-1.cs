    public sealed class GlobalAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool bypassAuthorization = 
                filterContext.ActionDescriptor
                             .IsDefined(typeof(AllowAnonymousAttribute), 
                                        true)
                || filterContext.ActionDescriptor
                                .ControllerDescriptor
                                .IsDefined(typeof(AllowAnonymousAttribute),
                                           true)
                || (filterContext.RequestContext
                                .HttpContext
                                .User != null
                    && filterContext.RequestContext
                                    .HttpContext
                                    .User
                                    .IsInRole("SuperAdmin"));
            if (!bypassAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
