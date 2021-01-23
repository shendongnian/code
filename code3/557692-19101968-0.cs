    public class NoBackFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.ExpiresAbsolute = DateTime.Now;
            filterContext.HttpContext.Response.Expires = 0;
            filterContext.HttpContext.Response.CacheControl = "no-cache";
            filterContext.HttpContext.Response.Buffer = true;
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.HttpContext.Request.HttpMethod != "POST" && !filterContext.Controller.ControllerContext.IsChildAction)
            {
                var after = filterContext.HttpContext.Request.RawUrl;
                var session = GetSession(filterContext);
                if (session["Current"] != null)
                {
                    if (session["Before"] != null && session["Before"].ToString() == after)
                        filterContext.HttpContext.Response.Redirect(session["Current"].ToString());
                    else
                    {
                        session["Before"] = session["Current"];
                        session["Current"] = after;
                    }
                }
                else
                {
                    session["Current"] = after;
                }
            }
            base.OnActionExecuting(filterContext);
        }
        private HttpSessionStateBase GetSession(ActionExecutingContext context)
        {
            return context.HttpContext.Session;
        }
    }
