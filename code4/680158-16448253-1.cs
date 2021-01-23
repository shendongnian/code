    public static class HttpServerUtilityExtensions
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void HandleError(this HttpServerUtility server, HttpContext httpContext)
        {
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                    currentController = currentRouteData.Values["controller"].ToString();
                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                    currentAction = currentRouteData.Values["action"].ToString();
            }
            var exception = server.GetLastError();
            Logger.ErrorException(exception.Message, exception);
            
            var controller = DependencyResolver.Current.GetService<ErrorController>();
            var routeData = new RouteData();
            var action = "InternalServerError";
            if (exception is HttpException)
            {
                var httpEx = exception as HttpException;
                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 401:
                        action = "AccessDenied";
                        break;
                }
            }
            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = exception is HttpException ? ((HttpException)exception).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;
            controller.ViewData.Model = new HandleErrorInfo(exception, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
    }
