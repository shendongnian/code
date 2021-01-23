    public class DebugModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.Form["hidden_var"] == "true")
            {
                var controller = filterContext.Controller as ControllerBase;
                if (controller != null)
                    controller.Debug = true;
            }
        }
    }
