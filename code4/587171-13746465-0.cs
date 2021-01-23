    var assembly = results.CompiledAssembly;
    var types = assembly.GetTypes();
    foreach (Type type in types)
    {
        string name = type.Name;
        var properties = type.GetProperties(); // public properties
        // etc
    }
