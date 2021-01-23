    public class CustomAuthorizeAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        //code that handles unauthorized ajax request
                    }
                    else
                    {
                        //code that handles http request
                    }
                }
    
                //you custom authorization logic
    
            }
        }
