    public class HandleCustomErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            
                var routeData = new RouteData();
                routeData.Values["controller"] = "Controller Name";
                routeData.Values["action"] = "Action Method Name";
                routeData.DataTokens["area"] = "Area Name"; // Optional
    
                IController errorsController = new Controllers.ErrorController();
                var rc = new RequestContext(new HttpContextWrapper(HttpContext.Current), 
                                                                               routeData);
                errorsController.Execute(rc);
            base.OnException(filterContext);
        }
    }
