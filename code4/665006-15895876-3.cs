    Type type = typeof (Bar);
    Type interfaceType = typeof (IFoo);
    var interfaceEvents = interfaceType.GetEvents(BindingFlags.DeclaredOnly 
                                                  | BindingFlags.Instance 
                                                  | BindingFlags.Public);
    var events = type.GetEvents(BindingFlags.DeclaredOnly 
                                | BindingFlags.Instance 
                                | BindingFlags.Public);
    events = events.Where(e => interfaceEvents.FirstOrDefault(
                    ie => ie.Name == e.Name && 
                    ie.EventHandlerType == e.EventHandlerType) == null).ToArray();
