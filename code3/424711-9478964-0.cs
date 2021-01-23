    var componentsWeDesire = Components.Where(c => typeof(IInputHandler).IsAssignableFrom(c.GetType()) 
                                                   || typeof(IUpdateable).IsAssignableFrom(c.GetType());
    foreach(var component in componentsWeDesire)
    {
        // ...
    }
