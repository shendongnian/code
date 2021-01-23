    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "MyArea_default",
            "MyDirectory/{controller}/{action}/{id}",
            new { action = "Create", id = UrlParameter.Optional }
        );
    }
