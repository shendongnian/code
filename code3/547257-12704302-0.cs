    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Processes HTTP requests that fail authorization.
        /// </summary>
        /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute"/>. The <paramref name="filterContext"/> object contains the controller, HTTP context, request context, action result, and route data.</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest()) filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
    
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
