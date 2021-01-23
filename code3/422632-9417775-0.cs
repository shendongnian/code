    private static readonly ReadOnlyCollection<Assembly> SystemAssemblies = 
        new List<Assembly> {
            typeof(string).Assembly, // mscorlib.dll
            typeof(Process).Assembly, // System.dll
        }.AsReadOnly();
    ...
    if (SystemAssemblies.Contains(type.Assembly))
    {
        ...
    }
