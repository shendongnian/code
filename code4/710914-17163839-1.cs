    context.MapRoute(
        "Test", 
        "SubFolder/Test",
        new { controller = "Test", action = "Index" },
        new[] { "MvcApplication.Controllers.SubFolder" }
    );
