    public class ControllerAndActionNameAttribute : ActionFilterAttribute
    {        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.ControllerName = filterContext.RequestContext.RouteData.Values["controller"].ToString();
            filterContext.Controller.ViewBag.ActionName = filterContext.RequestContext.RouteData.Values["action"].ToString();
            base.OnActionExecuting(filterContext);
        } 
    }
