    var taskTypes = (
        from type in typeof(ITask).Assemby.GetTypes()
        where typeof(ITask).IsAssignableFrom(type)
        where !type.IsAbstract && !type.IsGenericTypeDefinition
        select type)
        .ToList();
    // Register all as task types singleton
    taskTypes.ForEach(type => container.Register(type, type, Lifestyle.Singleton));
    // registers a list of all those (singleton) tasks.
    container.RegisterAll<ITask>(taskTypes);
