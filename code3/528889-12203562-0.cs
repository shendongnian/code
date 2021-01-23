    public class MyAttribute: ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {    
                if (filterContext.ActionParameters.ContainsKey("userId"))
                {
                    var userId = filterContext.ActionParameters["userId"] as Guid;
                    if (userId != null)
                    {
                        // Really?! Great!            
                    }
                }
            }
        } 
