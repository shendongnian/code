        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                     {
                                                                             {"area", ""},
                                                                             {"controller", "Error"},
                                                                             {"action", "NotAuthorized"},
                                                                             {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                                                                     });
            
        }
