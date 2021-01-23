            public class RightChecker : ActionFilterAttribute
            {
                public bool IsAdmin;            
    
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                   bool result = false;
                   if (filterContext.HttpContext.Request.QueryString["isAdmin"] != null)
                   {
                           bool.TryParse(filterContext.HttpContext.Request.QueryString["isAdmin"].ToString(), out result);
                   }
                    
                   if (IsAdmin != result) 
                   {
                       //your implementation
                   }
                }
            }
