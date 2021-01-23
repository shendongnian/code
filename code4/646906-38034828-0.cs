    MvcApplication app = (MvcApplication)HttpContext.ApplicationInstance;
    RouteCollection existingcoll = outeCollection)app.Application["ExistingRoutecolling"];
	
	foreach (Route _route in existingcoll)
     {
        // allow only those routes , which belongs to the area which you want allow to access the login user
        if (_route.Url == "Admin/{controller}/{action}/{id}")
            RouteTable.Routes.Add((RouteBase)_route);       
        // re-register routes again
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        // now redirect with expected action
        return RedirectToAction("controller", "action", new { area = "Admin" });
    }
