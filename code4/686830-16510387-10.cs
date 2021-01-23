    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var view = filterContext.Result as ViewResultBase;
            if(view != null)
            {
                var viewName = string.IsNullOrEmpty(view.ViewName) 
                                   ? filterContext.RouteData.Values["action"].ToString() 
                                   : view.ViewName;  // retrieve the custom view name if provided or default action name otherwise
                var cultureName = Thread.CurrentThread.CurrentUICulture.Name;
                var localizedViewName = string.Format("{0}_{1}", viewName, cultureName);  // construct composite, culture-aware name 
                if (ViewExists(localizedViewName))  // safety check in case not all your views are localized - if so, just return the default name
                {
                    filterContext.Result = new ViewResult { ViewName = localizedViewName };
                }                        
            }            
        }
        private bool ViewExists(string name)
        {
            var result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            return result.View != null;
        }
    }
