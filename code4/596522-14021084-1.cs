    public class PolicyViolationExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(PolicyViolationException))
            {
                var routeDictionary = new RouteValueDictionary(new
                {
                    area = "",
                    controller = "account",
                    action = "login"
                });
                // Redirect to specific page
                filterContext.HttpContext.Response.RedirectToRoute(routeDictionary);
                
                // Prevent to handle exceptions
                // Of 'PolicyViolationException' by default filters
                filterContext.ExceptionHandled = true;
            }
        }
    }
