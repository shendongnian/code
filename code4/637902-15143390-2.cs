    const string PluginTypeName = "MyCompany.MyProject.Contracts.IMyPlugin";
    /// <summary>Loads all plugins from a DLL file.</summary>
    /// <param name="fileName">The filename of a DLL, e.g. "C:\Prog\MyApp\MyPlugIn.dll"</param>
    /// <returns>A list of plugin objects.</returns>
    /// <remarks>One DLL can contain several types which implement `IMyPlugin`.</remarks>
    public List<IMyPlugin> LoadPluginsFromFile(string fileName)
    {
        Assembly asm;
        IMyPlugin plugin;
        List<IMyPlugin> plugins;
        Type tInterface;
        plugins = new List<IMyPlugin>();
        asm = Assembly.LoadFrom(fileName);
        foreach (Type t in asm.GetExportedTypes()) {
            tInterface = t.GetInterface(PluginTypeName);
            if (tInterface != null && (t.Attributes & TypeAttributes.Abstract) !=
                TypeAttributes.Abstract) {
                plugin = (IMyPlugin)Activator.CreateInstance(t);
                plugins.Add(plugin);
            }
        }
        return plugins;
    }
