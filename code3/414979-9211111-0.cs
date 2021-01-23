    Type[] types = myAssenbly.GetTypes();
    
    foreach(Type t in types)
    {
        // Is a Common Ancestor subclass
        bool isString = t.IsAssignableFrom(typeof(CommonAncestor));
    }
