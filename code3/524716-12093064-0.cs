    public class LiveOutputCacheAttribute : OutputCacheAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (VaryByParam == "false")
                return;
            base.OnActionExecuting(filterContext);
        }
    }
  
    ...
    [LiveOutputCache(Location=OutputCacheLocation.Server, VaryByParam="live")]
    public ActionResult Index(string name) 
    {
        ...
    }
