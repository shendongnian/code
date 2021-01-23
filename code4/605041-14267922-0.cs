    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class OptimizationsDebuggingAttribute : ActionFilterAttribute
    {
        private const String PARAM_NAME = "DisableOptimizations";
        private const String COOKIE_NAME = "MySite.DisableOptimizations";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Boolean parsedPref;
            Boolean optimizationsDisabled = false;
            if (filterContext.HttpContext.Request.QueryString[PARAM_NAME] != null)
            { // incoming change request
                var pref = filterContext.HttpContext.Request.QueryString[PARAM_NAME].ToString();
                if (Boolean.TryParse(pref, out parsedPref))
                {
                    optimizationsDisabled = parsedPref;
                }
            }
            else
            { // use existing settings
                var cookie = filterContext.HttpContext.Request.Cookies[COOKIE_NAME];
                if (cookie != null && Boolean.TryParse(cookie.Value, out parsedPref))
                {
                    optimizationsDisabled = parsedPref;
                }
            }
            // make the change
            System.Web.Optimization.BundleTable.EnableOptimizations = !optimizationsDisabled;
            // save for future requests
            HttpCookie savedPref = new HttpCookie(COOKIE_NAME, optimizationsDisabled.ToString())
            {
                Expires = DateTime.Now.AddDays(1)
            };
            filterContext.HttpContext.Response.SetCookie(savedPref);
            base.OnActionExecuting(filterContext);
        }
    }
