    context.MapRoute(null,
         "Customers/Products/{id}", // id is optional, so Customers/Products might reasonably return all products
         new { controller = "Products", action = "Details", id = UrlParameter.Optional },
         new {id = @"\d+"} // must be numeric if present
    );
    context.MapRoute(null,
         "Customers/Products/{action}/{id}", // Id is optional, so this needs an action.
         new { controller = "Products", action = "Details", id = UrlParameter.Optional }
         // maybe the id is not numeric for all actions? I don't know so I won't constrain it.
    );
    
    context.MapRoute(null,
         "Customers/{controller}/{action}", // Default Customers route
         new { controller = "customers", action = "Index" }
    );
