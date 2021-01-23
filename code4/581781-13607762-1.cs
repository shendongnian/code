    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                             {
                                                                 {"action", "Index"},
                                                                 {"controller", "Error"},
                                                                 {"id", "403"},  
                                                             });
    }
