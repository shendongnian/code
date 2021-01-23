        context.MapRouteLowercase(
        "AreaX.Log.Email",
        "areax/logs/{controller}/{action}/{id}",
        new
        {
            action = "Index",
            id = UrlParameter.Optional
        },
        new[] { ControllerNamespaces.AreaX }
    );
