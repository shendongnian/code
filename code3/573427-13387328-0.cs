    Area - AssetManagement
       Controller1 - HomeController 
                  Action1 - Add
                  Action2 - Delete 
    
       Controller2 - LocationsController
                  Action1 - Add
                  Action2 - Delete 
    routes.MapRoute(
        "AssetManagementLocations", // Route name
        "{Area}/{controller}/{action}/{id}", // URL with parameters
        new { controller = "Locations", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
        new[] { "MyApplication.Web.Website.Controllers" }
    );
