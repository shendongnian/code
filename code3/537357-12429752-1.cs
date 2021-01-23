    private readonly Type _pluginbaseType = typeof(BasePlugin);
    public AssemblyPlugin(Assembly assembly)
    {
                          
        Type[] _plugins = _assembly.GetExportedTypes()
            .Where(t => t.BaseType.IsSubclassOf(_pluginbaseType)
            .ToArray();
    }
