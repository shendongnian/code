    var types = loadedAssembly
        .GetTypes()
        .Where(t => type.IsAssignableFrom(typeof(IHandler)));
    foreach (var type in types)
    {
        if (factory.IsRegisteredHandler(name))
        {
            // usually you'll do nothing here, but now we check if handler
            // we want to register is marked with custom attribute so that
            // we can override already registered handler
            var canForceOverride = type.GetCustomAttributes(
                typeof(ForcesHandlerRegistrationOverride), true).Length > 0;
            if (canForceOverride)
            {
                factory.RegisterHandler(name, handler);
                // ...or to keep this one safe, add more appropriate method
                // for explicit replacement (see note below)
            }      
        }
        else
        {
            factory.RegisterHandler(name, handler);
        }
    }
