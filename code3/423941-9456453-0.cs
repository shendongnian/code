    var container = new WindsorContainer();
    container.Register(
        AllTypes.FromAssemblyContaining<EntityFrameworkLinkRepository>()
            .Where(type => typeof (IRepository).IsAssignableFrom(type))
            .WithService.Select((type, types) => type.BaseType != null && type.Name.EndsWith(type.BaseType.Name)
                                                        ? new[] {type.BaseType}
                                                        : Enumerable.Empty<Type>()));
