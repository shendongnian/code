    assembly.GetTypes()
        .Where(type => type.Name.EndsWith("CommandHandler"))
        .ToList()
        .ForEach(t => builder.RegisterType(t)
            .Named("concreteCommandHandler", typeof (ICommandHandler<>)
                .MakeGenericType(t.GetInterfaces()[0].GenericTypeArguments[0])
        ));
    builder.RegisterGeneric(typeof(FactoryCommandHandler<>)
       .WithParameter(
             (p, c) => true,
             (p, c) => c.ResolveNamed("concreteCommandHandler", p.ParameterType))
       .As(typeof(ICommandHandler<>));
