    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted ( ActionExecutedContext context )
        {
            context.HttpContext.Response.Cache.SetCacheability( HttpCacheability.NoCache );
        }
    }
    [HttpGet]
    [NoCache]
    public JsonResult GetSomeStuff ()
    {
        ...
    }
