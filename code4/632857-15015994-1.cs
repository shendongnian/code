    container.ResolveUnregisteredType += (sender, e) =>
    {
        var serviceType = e.UnregisteredServiceType;
        if (serviceType.IsGenericType &&
            serviceType.GetGenericTypeDefinition() == typeof(IDbCommandHandler<,>))
        {
            var commandArg = serviceType.GetGenericArguments()[0];
            var outputArg = serviceType.GetGenericArguments()[1];
        
            if (commandArg.IsGenericType &&
                commandArg.GetGenericTypeDefinition() == 
                    typeof(SubIdentifierItemCreateCommand<,>))
            {
                var itemTypeArgument = commandArg.GetGenericArguments()[0];
                var defaultValuesArgument = commandArg.GetGenericArguments()[1];
                
                if (itemTypeArgument != outputArg)
                {
                    return;
                }
                
                Type typeToRegister;
                
                try
                {
                    typeToRegister =
                        typeof(SubIdentifierItemCreateCommandHandler<,>)
                        .MakeGenericType(itemTypeArgument.GetGenericArguments());
                }
                catch (ArgumentException)
                {
                    // Thrown by MakeGenericType when the type constraints 
                    // do not match. In this case, we don't have to register
                    // anything and can bail out.
                    return;
                }
                object singleInstance = container.GetInstance(typeToRegister);
                // Register the instance as singleton.
                e.Register(() => singleInstance);
            }
        }
    };
