    var catalog = new AggregateCatalog();
    var locations = new List<string>();
    foreach (var loc in GetPluginDirectories())
        if (!locations.Contains(loc))
        {
            catalog.Catalogs.Add(new DirectoryCatalog(loc));
            locations.Add(loc);
        }
    var asm = Assembly.GetExecutingAssembly();
    if (!locations.Contains(Path.GetDirectoryName(asm.Location)))
        catalog.Catalogs.Add(new AssemblyCatalog(asm));
