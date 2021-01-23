    public ActionResult myaction(string allsegments)
    {
        var urlsegments = allsegments.split('/');
        //...
    }
    routes.MapRoute("betterroute",
            "myaction/{*allsegments}",
            new { controller = "mycontroller", action = "myaction"}
            );
