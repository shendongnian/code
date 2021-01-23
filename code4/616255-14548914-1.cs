    container.ResolveUnregisteredType += (s, e) =>
    {
        Type type = e.UnregisteredType;
        if (typeof(ISetting).IsAssignableFrom(type))
        {
            // If you need raw performance, there is also
            // an overload that takes in an Expression.
            e.Register(() =>
            {
                // Do something useful here. Example:
                return Activator.CreateInstance(type);
            });
        }
    };
