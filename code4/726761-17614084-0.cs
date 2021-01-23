    public class HandleAjaxErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = "Error";
                routeData.DataTokens["area"] = "app";
    
                IController errorsController = new Controllers.ErrorController();
                var rc = new RequestContext(new HttpContextWrapper(HttpContext.Current), routeData);
                errorsController.Execute(rc);
            base.OnException(filterContext);
        }
    }
