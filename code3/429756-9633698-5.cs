    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "User_default",
            "User/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional },
            new string[] { "SandboxMvcApplication.Areas.Admin.Controllers" }
        );
    }
