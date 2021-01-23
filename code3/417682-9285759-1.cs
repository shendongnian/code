    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.Add(
            "MyRoute", 
            new MyRoute(
                new Dictionary<string, string> 
                { 
                    { "BizContacts", "1" },
                    { "HomeContacts", "3" },
                    { "OtherContacts", "4" },
                }
            )
        );
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
