    public IEnumerable<IMappingProvider> GetAllMappings(MappingMode mode)
    {
        yield return new UserMap();
    
        var fooMap = new FooMap();
        if (mode == MappingMode.Reporting)
            fooMap.ReadOnly();
        yield return fooMap
    }
    var model = new PersistenceModel();
    foreach (var mapping in GetAllMappings(mappingMode)
    {
        model.Add(mapping);
    }
    Fluently.Configure().Mappings(m => m.UsePeristenceModel(model))
