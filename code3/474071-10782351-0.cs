    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (type.IsAssignableFrom(typeof(ISource)))
        {
            sources.Add((ISource)Activator.CreateInstance(type));
        }
    }
