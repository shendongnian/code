    container.ResolveUnregisteredType += (s, e) =>
    {
        Type type = e.UnregisteredType;
        if (typeof(ISetting).IsAssignableFrom(type))
        {
            e.Register(() =>
            {
                // Do something useful here. Example:
                return Activator.CreateInstance(type);
            });
        }
    };
