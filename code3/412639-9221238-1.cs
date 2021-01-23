    private void RegisterRoutes()
    {
        // `TypeHelper.GetTypes().FilterTypes<T>` will find all of the types in the
        // current AppDomain that:
        // - Implement T if T is an interface
        // - Are decorated with T if T is an attribute
        // - Are children of T if T is anything else
        foreach (var type in TypeHelper.GetTypes()
                                       .FilterTypes<ServiceRouteAttribute>())
        {
            // routeAttrs should never be null or empty because only types decorated
            // with `ServiceRouteAttribute` should ever get here.
            // `GetAttribute<T>` is my extension method for `MemberInfo` which returns all
            // decorations of `type` that are T or children of T
            var routeAttrs = type.GetAttributes<ServiceRouteAttribute>();
        
            foreach (var routeAttr in routeAttrs)
            {
                // Some dupe and error checking
    
                var routePrefix = routeAttr.RoutePrefix;
                if (string.IsNullOrEmpty(routePrefix))
                    routePrefix = type.Name;
                RouteTable.Routes.Add(new ServiceRoute(routePrefix, 
                                                       routeAttr.ServiceFactory,
                                                       type));
            }
        }
    }
