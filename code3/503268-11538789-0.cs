    public class GlobalViewBagInjectorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Foo = "bar";
        }
    }
