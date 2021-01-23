    public class LocalizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string culture = filterContext.HttpContext.Request.RequestContext.RouteData.Values["culture"].ToString();
            string subUser = filterContext.HttpContext.Request.RequestContext.RouteData.Values["subUser"].ToString();       
        }
    }
