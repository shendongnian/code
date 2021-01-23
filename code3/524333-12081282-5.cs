    ...
    [ImportMany]
    public IEnumerable<IModule> ModulesAvailable {get;set;}
    ...
    public void LoadModules(string path) {
        DirectoryCatalog catalog = new DirectoryCatalog(path);
        catalog.ComposeParts(this);
    }
