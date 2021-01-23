    // Obtain a reference to the navigation property you are interested in
    var navProp = GetNavigationProperty();
    // Load the metadata workspace
    MetadataWorkspace metadataWorkspace = null;
    bool allMetadataLoaded =loader.TryLoadAllMetadata(inputFile, out metadataWorkspace);
    
    // Get the association type from the storage model
    var association = metadataWorkspace
        .GetItems<AssociationType>(DataSpace.SSpace)
        .Single(a => a.Name == navProp.RelationshipType.Name)
    
    // Then look at the referential constraints
    var toColumns = String.Join(",", 
        association.ReferentialConstraints.SelectMany(rc => rc.ToProperties));
    var fromColumns = String.Join(",", 
        association.ReferentialConstraints.SelectMany(rc => rc.FromProperties));
