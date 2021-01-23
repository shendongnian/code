    var domain = AppDomain.CurrentDomain;
    var assemblies = domain.GetAssemblies();
    foreach(var assembly in assemblies)
    {
        foreach(Type t in assembly.GetTypes())
        {
            string name = t.Name; // or t. Fullname if you know it
            // you can also check if the type is an Enum, etc...
        }
    }
