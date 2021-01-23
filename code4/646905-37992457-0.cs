    public class MvcApplication : System.Web.HttpApplication
     {
            protected void Application_Start()
            {
    		    AreaRegistration.RegisterAllAreas();
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
    			
    			RouteCollection existingcoll = new RouteCollection();
    
                foreach (Route _route in RouteTable.Routes)
                    existingcoll.Add((RouteBase)_route);
                //keep all default registerd routes in Asp Application object  
                Application["ExistingRoutecolling"] = existingcoll;
            }
    }
    //after login when user called first action to render dashboard, you can add logic there
     public ActionResult ModuleDashboard
     {
         //get default registerd routes from Asp Application object which we stored in  Application_Start() method 
    	MvcApplication app = (MvcApplication)HttpContext.ApplicationInstance;
    	RouteCollection existingcoll = (RouteCollection)app.Application["ExistingRoutecolling"];
    
    	// remove all register routes, by default those are registered by application object
    	while (RouteTable.Routes.Count > 0)
    		RouteTable.Routes.RemoveAt(0);
    					
    	//navigate each route from collection and add in actual application route collection object			
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
    					
     }
