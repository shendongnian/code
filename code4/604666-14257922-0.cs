    routes.MapRoute("Name", "param/{*params}", new { controller = ..., action = ... });
    ActionResult MyAction(string params) {
        foreach(string param in params.Split("/")) {
            ...
        }
    }
