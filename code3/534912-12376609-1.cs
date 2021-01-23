    [TestMethod]
    public void CompositionRoot_IntegrationTest()
    {
        // Arrange
        CompositionRoot.Bootstrap();
    
        var webFormsAssembly = typeof(HomePage).Assembly;
    
        var rootTypes =
            from type in webFormsAssembly.GetExportedTypes()
            where !type.IsAbstract
            where typeof(Page).IsAssignableFrom(type) ||
                typeof(UserControl).IsAssignableFrom(type)
            select type;
            
        // Act
        foreach (Type rootType in rootTypes)
        {
            CompositionRoot.GetInstance(rootType);
        }
    }
