    public IEnumerable<EventInfo> GetEventsEx(Type type)
    {
        var interfaceEvents = new List<EventInfo>();
        foreach (var interfaceType in type.GetInterfaces())
        {
            interfaceEvents.AddRange(interfaceType.GetEvents(
                BindingFlags.DeclaredOnly
                | BindingFlags.Instance
                | BindingFlags.Public));
        }
        var events = type.GetEvents(
            BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public);
        return events.Where(e => interfaceEvents.FirstOrDefault(
                ie => ie.Name == e.Name &&
                ie.EventHandlerType == e.EventHandlerType) == null);
    }
