    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Admin_default",
            "Admin/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional },
            new string[] { "SandboxMvcApplication.Areas.Admin.Controllers" }
        );
    }
