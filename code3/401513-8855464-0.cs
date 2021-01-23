    [CacheControl(HttpCacheability.NoCache), HttpGet]
    public ActionResult MyAction() { return Json("Hi!", JsonRequestBehavior.AllowGet); }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class CacheControlAttribute : ActionFilterAttribute
    {
        public CacheControlAttribute(HttpCacheability cacheability)
        {
            this._cacheability = cacheability;
        }
        public HttpCacheability Cacheability { get { return this._cacheability; } } 
        private HttpCacheability _cacheability;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            cache.SetCacheability(_cacheability);
        }
    }
