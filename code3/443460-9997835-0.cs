    protected override void ConfigureModuleCatalog()
    {
        string path = @"libs\FooLib.dll";
        var assembly = Assembly.LoadFrom(path);
        var type = assembly.GetType("FooLib.FooModule");
        ModuleCatalog.AddModule(new ModuleInfo
                                    {
                                        ModuleName = type.Name,
                                        ModuleType = type.AssemblyQualifiedName,
                                        Ref = new Uri(path, UriKind.RelativeOrAbsolute).AbsoluteUri
                                    });
    }
