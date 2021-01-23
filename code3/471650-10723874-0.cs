    routes.MapRoute(
      "Default",
      "{controller}/{action}/{id}", // URL pattern
       new { controller = "Home", action = "Index" },
       new { id = UrlParameter.Optional }
    );
    routes.MapRoute(
      "Dashboard",
      "dashboards/{id}-{name}", // URL pattern
       new { controller = "Dashboards", action = "Index" },
       new { id = @"\d+", name = UrlParameter.Optional }
    );
