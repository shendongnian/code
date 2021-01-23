    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var fooCookie = filterContext.HttpContext.Request.Cookies["foo"];
            // TODO: do something with the foo cookie
        }
    }
