    [TestMethod]
    public void CompositionRoot_IntegrationTest()
    {
        // Arrange
        CompositionRoot.Bootstrap();
    
        var mvcAssembly = typeof(HomeController).Assembly;
    
        var controllerTypes =
            from type in mvcAssembly.GetExportedTypes()
            where typeof(IController).IsAssignableFrom(type)
            where !type.IsAbstract
            where !type.IsGenericTypeDefinition
            where type.Name.EndsWith("Controller")
            select type;
        // Act
        foreach (var controllerType in controllerTypes)
        {
            CompositionRoot.GetInstance(controllerType);
        }
    }
    
