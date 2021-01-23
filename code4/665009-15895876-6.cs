    public IEnumerable<EventInfo> GetEventsEx(Type type)
    {
        var baseEvents = new List<EventInfo>();
        // Adds Events of interfaces to baseEvents
        foreach (var interfaceType in type.GetInterfaces())
        {
            baseEvents.AddRange(interfaceType.GetEvents(
                BindingFlags.DeclaredOnly
                | BindingFlags.Instance
                | BindingFlags.Public));
        }
        // Adds Events of base classes to baseEvents
        var baseType = type.BaseType;
        while (baseType != typeof (object))
        {
            baseEvents.AddRange(baseType.GetEvents(
                BindingFlags.DeclaredOnly
                | BindingFlags.Instance
                | BindingFlags.Public));
            baseType = baseType.BaseType;
        }
        // Get events for type
        var events = type.GetEvents(
            BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public);
        // Remove baseEvents and return
        return events.Where(e => baseEvents.FirstOrDefault(
                ie => ie.Name == e.Name &&
                ie.EventHandlerType == e.EventHandlerType) == null);
    }
