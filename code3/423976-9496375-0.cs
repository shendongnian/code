    var directoryPath = "Dll folder path";
    //Load parts from the available dlls in the specified path using the directory catalog
    var directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");
    //Creating an instance of aggregate catalog. It aggregates other catalogs
    var aggregateCatalog = new AggregateCatalog();
    aggregateCatalog.Catalogs.Add(directoryCatalog);
    //Crete the composition container
    var container = new CompositionContainer(aggregateCatalog);
    
    container.ComposeParts(this);
    [ImportMany]
    public List<IModule> Modules { get; set; }
