    // gather plugin assemblies
    string applicationPath = Path.GetDirectoryName(
        Assembly.GetEntryAssembly().Location);
    string pluginsPath = Path.Combine(applicationPath, "plugins");
    Assembly[] pluginAssemblies = 
        Directory.EnumerateFiles(pluginsPath, "*.dll")
        .Select(path => Assembly.LoadFile(path))
        .ToArray();
    // register types
    var builder = new ContainerBuilder();
    builder.Register<IFoo>(context => new DefaultFoo());
    builder.RegisterAssemblyTypes(pluginAssemblies)
        .AsImplementedInterfaces(); 
    // test which IFoo implementation is selected
    var container = builder.Build();
    IFoo foo = container.Resolve<IFoo>();
    Console.WriteLine(foo.GetType().FullName);
