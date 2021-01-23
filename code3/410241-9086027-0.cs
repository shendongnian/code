    [EntityContext] etContext = new [EntityContext]();
    var csdl = etContext.MetadataWorkspace.GetItemCollection(DataSpace.CSpace);
    var entity = csdl.GetItems<EntityType>().Where(e => e.Name = [EntityType]).SingleOrDefault();
    var edmProperty = entity.Properties.Where(p => p.Name == [PropertyName]).SingleOrDefault();
    var mode = edmProperty.TypeUsage.Facets.Where(f => f.Name ==     "ConcurrencyMode").SingleOrDefault();
