        private static void RegisterHandlers(
            ContainerBuilder builder, 
            Type handlerType,
            params Type[] decorators)
        {
            RegisterHandlers(builder, handlerType);
            for (int i = 0; i < decorators.Length; i++)
            {
                RegisterGenericDecorator(
                    builder,
                    decorators[i],
                    handlerType,
                    i == 0 ? handlerType : decorators[i - 1],
                    i != decorators.Length - 1);
            }
        }
        private static void RegisterHandlers(ContainerBuilder builder, Type handlerType)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .As(t => t.GetInterfaces()
                        .Where(v => v.IsClosedTypeOf(handlerType))
                        .Select(v => new KeyedService(handlerType.Name, v)))
                .InstancePerRequest();
        }
        private static void RegisterGenericDecorator(
            ContainerBuilder builder,
            Type decoratorType,
            Type decoratedServiceType,
            Type fromKeyType,
            bool hasKey)
        {
            var result = builder.RegisterGenericDecorator(
               decoratorType,
               decoratedServiceType,
               fromKeyType.Name);
            if (hasKey)
            {
                result.Keyed(decoratorType.Name, decoratedServiceType);
            }
        }
