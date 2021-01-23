    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NoCacheResponseAttribute());
        }
    }
    public class NoCacheResponseAttribute : BaseActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           var response = filterContext.RequestContext.HttpContext.Response;
           response.Cache.SetCacheability(HttpCacheability.NoCache);
           response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
           response.Cache.SetNoStore();
        }
    }
