    var container = new WindsorContainer();
    container.Register(
        AllTypes.FromAssemblyContaining<EntityFrameworkLinkRepository>()
            .BasedOn<IRepository>()
            .WithService.Select((type, types) => type.BaseType != null && type.Name.EndsWith(type.BaseType.Name)
                                                        ? new[] {type.BaseType}
                                                        : Enumerable.Empty<Type>()));
