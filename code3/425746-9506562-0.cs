    public override void RegisterArea(AreaRegistrationContext context)
    {
    	context.MapRoute(
    		"MyArea_default",
    		"MyArea/Foo/{action}/{id}",
    		new { action = "Index", id = UrlParameter.Optional }
    	);
    }
