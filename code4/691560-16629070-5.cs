    public class Localize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // .. irrelevent logic here ..
    
            filterContext.Result = new PermanentRedirectResult("/" + cookieLanguage);
        }
    }
