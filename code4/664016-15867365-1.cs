    var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
    
    // and just to get you started... 
    var baseset = objectContext
        .MetadataWorkspace
        .GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace)
        .BaseEntitySets
        .First(meta => meta.ElementType.Name == "MyBaseClass");
    var elementType = objectContext
        .MetadataWorkspace
        .GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace)
        .BaseEntitySets
        .First(meta => meta.ElementType.Name == "MyBaseClass")
        .ElementType;
    EdmMember member = elementType.Members[2]; // e.g. 3rd property
    Facet item;
    if (member.TypeUsage.Facets.TryGetValue("StoreGeneratedPattern", false, out item))
    {
        var value = ((StoreGeneratedPattern)item.Value) == StoreGeneratedPattern.Computed;
    }
