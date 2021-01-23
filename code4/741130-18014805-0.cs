    static class AutofacRegistration
    {
        public static IContainer RegisterHandlers()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AutofacRegistration)))
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<TestCommandHandler>()
                   .Named<ICommandHandler<TestCommand>>("TestHandler")
                   .InstancePerLifetimeScope();
            // this works!
            builder.Register(c => new TestCommandHandlerDecorator(c.ResolveNamed<ICommandHandler<TestCommand>>("TestHandler")))
                   .As<ICommandHandler<TestCommand>>()
                   .InstancePerLifetimeScope();
            return builder.Build();
        }
    }
