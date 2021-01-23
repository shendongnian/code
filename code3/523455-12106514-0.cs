    private Type GetControllerTypeWithinNamespaces(RouteBase route, string controllerName, HashSet<string> namespaces) {
        ControllerTypeCache.EnsureInitialized(BuildManager);
        ICollection<Type> matchingTypes = ControllerTypeCache.GetControllerTypes(controllerName, namespaces);
 
        ... more code removed for brevity
    }
