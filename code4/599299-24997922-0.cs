    public class IsAuthorizedAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var sessions = filterContext.HttpContext.Session;
                    if (sessions["User"] != null)
                    {
                        return;
                    }
                    else
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                status = "401"
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
    
                        //xhr status code 401 to redirect
                        filterContext.HttpContext.Response.StatusCode = 401;
    
                        return;
                    }
                }
    
                var session = filterContext.HttpContext.Session;
                if (session["User"] != null)
                    return;
    
                //Redirect to login page.
                var redirectTarget = new RouteValueDictionary { { "action", "LogOn" }, { "controller", "Account" } };
                filterContext.Result = new RedirectToRouteResult(redirectTarget);
            }
        }
