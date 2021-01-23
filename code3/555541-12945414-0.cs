    // An aggregate catalog that combines multiple catalogs
    var catalog = new AggregateCatalog();
    // Adds all the parts found in the necessary assemblies
    catalog.Catalogs.Add(new AssemblyCatalog(typeof(IGlyphService).Assembly));
    catalog.Catalogs.Add(new AssemblyCatalog(typeof(SmartTagSurface).Assembly));
    // Create the CompositionContainer with the parts in the catalog
    CompositionContainer mefContainer = new CompositionContainer(catalog);
    // Fill the imports of this object
    mefContainer.ComposeParts(this);
