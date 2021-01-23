    Configuration cfg = new Configuration();
    cfg.Configure();
    
    // Add class mappings to configuration object
    Assembly mappingAssembly = AssemblyContatingTheCategoryMappingXMLFile;
    cfg.AddAssembly(mappingAssembly);
