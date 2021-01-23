    public class RedirectDetect: ActionFilterAttribute{
       public override void OnActionExecuted(ActionExecutedContext filterContext){
            if (filterContext.Result is RedirectToRouteResult ||
                filterContext.Result is RedirectResult)
            {
                 TempData["Redirected"] = true;
                 //or what ever other indicator you want to set
            }
       }
    }
