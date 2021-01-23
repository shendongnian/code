    public class MyBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["myCookie"];
    
            //do something with cookie.Value
            if (cookie!=null) 
            {
               filterContext.ActionParameters["YearId"] = cookie.Value;
            }
            else
            {
               // do something here
            }
        }
    }
