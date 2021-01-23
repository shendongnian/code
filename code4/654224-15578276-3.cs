    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
    {
        var a = Attribute.GetCustomAttribute(type, typeof(AppInitialized), true) 
            as AppInitialized;
        if (a != null)
            a.Initialize();
    }
