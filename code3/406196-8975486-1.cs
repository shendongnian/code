    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("",
            "Default", //RouteName
            "{controller}/{action}/{id}", // URL,with parameters
            new  
               {
                  controller="yourControllerName", 
                  action="yourView"
                  ID="ifAnyUrl Parameter Needed"
    
               }
    }
