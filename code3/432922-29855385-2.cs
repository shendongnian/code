    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterTypes(
        AllClasses.FromLoadedAssemblies(),
        WithMappings.FromMatchingInterface,
        WithName.Default);
    }
