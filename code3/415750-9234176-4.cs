        Dictionary<string, List<string>> controllersAndActions = new Dictionary<string, List<string>>();
        // Get all the controllers
        var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Controller).IsAssignableFrom(t));
        foreach (var controller in controllers)
        {
            List<string> actions = new List<string>();
            //Get all methods without HttpPost and with return type action result
            var methods = controller.GetMethods().Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)).Where(a=>!a.GetCustomAttributes(typeof(HttpPostAttribute),true).Any());
            methods.ToList().ForEach(a => {
                actions.Add(a.Name);
            });
            var controllerName = controller.Name;
            if (controllerName.EndsWith("Controller"))
            {
                var nameLength = controllerName.Length - "Controller".Length;
                controllerName = controllerName.Substring(0, nameLength);
            }
            controllersAndActions.Add(controllerName, actions);
        }
        List<string> allowedRoutes = new List<string>();
        var routeNames = RouteTable.Routes.Where(o=>o.GetRouteData(this.HttpContext)!=null).Select(r=>r.GetRouteData(this.HttpContext).DataTokens["RouteName"].ToString());
        foreach (var cName in controllersAndActions)
        {
            foreach (var aName in cName.Value)
            {
                foreach (var item in routeNames)
                {
                    allowedRoutes.Add(GenerateUrl(item, aName, cName.Key, RouteTable.Routes, this.Request.RequestContext));
                }
            }
            
        }
