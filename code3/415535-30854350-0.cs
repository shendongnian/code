    var controllerClasses = AllClasses.FromLoadedAssemblies()
        .Where(t => t.FullName.Contains("Controller")).ToList();
    var nonControllerClasses = AllClasses.FromLoadedAssemblies()
        .Where(t => !t.FullName.Contains("Controller")).ToList();
    
    container.RegisterTypes(controllerClasses, WithMappings.FromMatchingInterface, WithName.Default);
    container.RegisterTypes(nonControllerClasses, WithMappings.FromMatchingInterface, WithName.Default,
        type => new ContainerControlledLifetimeManager());
