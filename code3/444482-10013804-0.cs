    routes.MapRoute(
                "TestRoute",
                "{path}/{controller}/{action}/{id}",
                new { controller = "Space", action = "Index", id = UrlParameter.Optional },
                new { path = @"TEST" },
                new string[] { "The.Namespace" });
