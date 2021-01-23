    [Attribute]
    public class TokenLoginAttribute : ActionFilterAttribute
    {
        public overrides void OnActionExecuting(ActionExecutingFilterContext filterContext)
        {
            // Perform your login based on values in the querystring here
        }
    }
    
