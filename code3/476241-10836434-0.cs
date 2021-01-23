    // use reflection to get all derived types
    List<type> knownTypes = new List<type>();
    // Iterate over whichever assembly has your types.
    foreach(Type t in Assembly.GetExecutingAssembly().GetTypes())
        if (typeof(Car).IsAssignableFrom(t) || 
            typeof(Wheel).IsAssignableFrom(t) ||
            typeof(Door).IsAssignableFrom(t))
           knownTypes.Add(t);
     
    // prepare to serialize a car object
    XmlSerializer serializer = new XmlSerializer(typeof(Car), knownTypes.ToArray());
