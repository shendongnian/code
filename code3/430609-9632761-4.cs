    public class CheckEmailAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            // if the cookie isn't set the a user never provided their details
            if (request.Cookies["mycookiename"] == null)
            {
                // Set it to the correct result, to redirect the user to provide their email address
                filterContext.Result = new ViewResult { ViewName = "GetEmailAddress" };
                // filterContext.HttpContext.Response.AppendCookie(new HttpCookie("mycookiename", "true"));
            }
            else
            {
                // Don't do anything, the user already provided their email address
            }
    
        }
    }
