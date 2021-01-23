    // You'd probably do this once and cache it, of course...
    var typeMap = someAssembly.GetTypes()
                              .ToDictionary(t => t.FullName, t => t,
                                            StringComparer.OrdinalIgnoreCase);
    ...
    Type type;
    if (typeMap.TryGetValue(name, out type))
    {
        ...
    }
    else
    {
        // Type not found
    }
