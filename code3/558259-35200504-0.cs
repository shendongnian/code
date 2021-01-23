    public class AllowCrossSiteJsonAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext != null && filterContext.HttpContext.Response != null && filterContext.HttpContext.Request != null && filterContext.HttpContext.Request.UrlReferrer != null)
            {
                var allowedCrossDomains = TypeSafeConfigurationManager.GetValueString("allowedCrossDomains", "none");
                var allowedHosts = allowedCrossDomains.Split(',');
                var requestHost =  filterContext.HttpContext.Request.UrlReferrer.GetLeftPart(UriPartial.Authority);
                if (allowedHosts.Contains(requestHost.ToLower()))
                {
                    filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", requestHost);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
    public class AllowCrossSiteJsonForWebApiAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null && actionExecutedContext.Request != null &&
                actionExecutedContext.Request.Headers.Referrer != null)
            {
                var allowedCrossDomains = TypeSafeConfigurationManager.GetValueString("allowedCrossDomains", "none");
                var allowedHosts = allowedCrossDomains.Split(',').ToList();
                var requestHost = actionExecutedContext.Request.Headers.Referrer.GetLeftPart(UriPartial.Authority);
                if (allowedHosts.Contains(requestHost.ToLower()))
                {
                    actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", requestHost);
                }
                base.OnActionExecuted(actionExecutedContext);
            }
        }
    }
