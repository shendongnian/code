     public interface IDbCommandHandler<in TCommand>: IDbCommandHandlerStub
        where TCommand : IDbCommand
    {
        void Handle(TCommand command);
    }
    public interface IDbCommandHandlerStub
    {
    }
        private List<Type> getTypesThatImplementIDbCommandHandler(IEnumerable<Assembly> assemblyList)
        {
            List<Type> list = new List<Type>();
            foreach (var a in assemblyList)
            {
                var matches = a.GetTypes().Where(t => typeof(IDbCommandHandlerStub).IsAssignableFrom(t));
                list.AddRange(matches);
            }
            return list;
        }
    private void registerDbCommands(List<Type> dbCommandHandlerTypes, ContainerBuilder builder)
        {
            foreach (var t in dbCommandHandlerTypes)
            {
                var interfaces = t.GetInterfaces();
                foreach (var i in interfaces)
                {
                    builder.RegisterType(t).Named("dbCommand", i);
                }
            }
        }
       public void Test1()
       {
            ContainerBuilder builder = new ContainerBuilder();
            var dbCommandHandlerTypes = getTypesThatImplementIDbCommandHandler(assemblies);
            registerDbCommands(dbCommandHandlerTypes, builder);            
            builder.RegisterGenericDecorator(typeof(DbCommandWithTransactionHandlerDecorator<>),
                                            typeof(IDbCommandHandler<>),
                                            fromKey: "dbCommand", toKey:"dbCommandWithTransaction").SingleInstance();
            builder.RegisterGenericDecorator(typeof(DbOptimisticConcurrencyRetryDecorator<>),
                                            typeof(IDbCommandHandler<>),
                                            fromKey: "dbCommandWithTransaction").SingleInstance();
            var container = builder.Build();
            var handler1 = container.Resolve<IDbCommandHandler<CreateNewNotificationCommand>>();
    }
