    public override void RegisterArea(AreaRegistrationContext context)
    {
    context.MapRoute(
            "Products_Details",
            "Customers/Products/{id}",
            new { controller="Products", action="Details" },
            new { id = @"\d+" }
        );
        context.MapRoute(
            "Customers_default",
            "Customers/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional }
        );
    }
