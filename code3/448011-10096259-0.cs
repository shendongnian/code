    // register all modules
    protected override void ConfigureModuleCatalog()
    {
        // get all module types
        var types = new List<Type>();
        types.Add(typeof(ModuleA));
        types.Add(typeof(ModuleB));
        types.Add(typeof(ModuleC));
        // register all types
        foreach (var type in types)
        {
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = type.Name,
                ModuleType = type.AssemblyQualifiedName
            });
        }
    }
