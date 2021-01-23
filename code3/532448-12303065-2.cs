    public class BaseController : Controller {
       protected const String ModelStateTempData = "ModelStateTempData";
       protected Boolean PreserveModelState { get; set; }
       
       protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        {
            if(PreserveModelState)
              TempData[ModelStateTempData] = ModelState;
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          if (TempData[ModelStateTempData] != null && !ModelState.Equals(TempData[ModelStateTempData]))
                ModelState.Merge((ModelStateDictionary)TempData[ModelStateTempData]);
          base.OnActionExecuting(filterContext);
        }
    }
