    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);            
            var view = filterContext.Result as ViewResultBase;
            if(view != null)
            {
                var viewName = string.IsNullOrEmpty(view.ViewName) 
                                   ? filterContext.RouteData.Values["action"] 
                                   : view.ViewName;  // retrieve the custom view name if provided or default action name otherwise
                var culture = Thread.CurrentThread.CurrentUICulture.Name;
                filterContext.Result = new ViewResult {ViewName = string.Format("{0}_{1}", viewName, culture)};  // construct composite, culture-aware name             
            }            
        }
    }
