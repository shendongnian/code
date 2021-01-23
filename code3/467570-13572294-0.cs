    [AttributeUsage(AttributeTargets.All)]
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //write your logic 
            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
            redirectTargetDictionary.Add("area", "");
            redirectTargetDictionary.Add("action", "Error");
            redirectTargetDictionary.Add("controller", "Home");
            filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);   
        }
    }
