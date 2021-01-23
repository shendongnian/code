    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (typeof(ISource).IsAssignableFrom(type))
        {
            sources.Add((ISource)Activator.CreateInstance(type));
        }
    }
