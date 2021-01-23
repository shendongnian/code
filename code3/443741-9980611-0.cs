    private static CreateInstance(string assemblyName, string typeName)
    {
        var assembly = Assembly.LoadFrom(assemblyName);
        if (assembly == null)
            throw new InvalidOperationException(
               "The specified assembly '" + assemblyName + "' did not load.");
        Type type = assembly.GetType(typeName);
        if (type == null)
            throw new InvalidOperationException(
               "The specified type '" + typeName + "' was not found in assembly '" + assemblyName + "'");
        return Activator.CreateInstance(type);
    }
