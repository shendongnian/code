    const string PluginTypeName = "MyCompany.MyProject.Contracts.IMyPlugin";
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
