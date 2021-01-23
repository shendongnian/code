    public class CacheControl : System.Web.Http.Filters.ActionFilterAttribute
    {
        public int MaxAge { get; set; }
        public CacheControl()
        {
            MaxAge = 3600;
        }
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            context.Response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromSeconds(MaxAge)
            };
            base.OnActionExecuted(context);
        }
    }
