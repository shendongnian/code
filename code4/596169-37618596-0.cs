    public override void RegisterArea(AreaRegistrationContext context) 
    {
        context.MapRoute(
            "Admin_default",
            "Admin/{controller}/{action}/{id}",
            new {controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Web.Areas.Admin.Controllers" }
        );
    }
