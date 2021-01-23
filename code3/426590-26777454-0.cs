        IUnityContainer container = new UnityContainer();
        // Do not register ApiControllers with Unity.
        List<Type> typesOtherThanApiControllers
            = AllClasses.FromLoadedAssemblies()
                .Where(type => (null != type.BaseType)
                               && (type.BaseType != typeof (ApiController))).ToList();
        container.RegisterTypes(
            typesOtherThanApiControllers,
            WithMappings.FromMatchingInterface,
            WithName.Default,
            WithLifetime.ContainerControlled);
