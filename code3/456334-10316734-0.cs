        public class MenuAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting (ActionExecutingContext filterContext)
            {
                var requestRoute = filterContext.RouteData.Route;
                var currentUser = WebWorker.CurrentUser; // Or wathever is your thing to get the current user from session
                if (currentUser != null && !MenuAccessService.UserHasAccessToRoute(currentUser, requestRoute))
                {
                    filterContext.Result = new RedirectToRouteResult("MenuAccessDenied");
                }
                base.OnActionExecuting(filterContext);
            }
        }
