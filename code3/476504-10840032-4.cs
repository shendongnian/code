    routes.MapRoute(
      "{controller}/{id}", // URL with parameters
      new { controller = "Home", action = "Get", id = UrlParameter.Optional },
      new { httpMethod = new HttpMethodConstraint("GET") }
    );
    routes.MapRoute(
      "{controller}/{id}", // URL with parameters
      new { controller = "Home", action = "Put", id = UrlParameter.Optional },
      new { httpMethod = new HttpMethodConstraint("PUT") }
    );
    routes.MapRoute(
      "{controller}/{id}", // URL with parameters
      new { controller = "Home", action = "Post", id = UrlParameter.Optional },
      new { httpMethod = new HttpMethodConstraint("POST") }
    );
    routes.MapRoute(
      "{controller}/{id}", // URL with parameters
      new { controller = "Home", action = "Delete", id = UrlParameter.Optional },
      new { httpMethod = new HttpMethodConstraint("DELETE") }
    );
    routes.MapRoute(
      "Default", // Route name
      "{controller}/{id}", // URL with parameters
      new { controller = "Home", action = "Restifier", id = UrlParameter.Optional }
    );
