    context.MetadataWorkspace.GetItemCollection(DataSpace.CSpace)
        .OfType<EntityType>()
        .SelectMany(entityType => entityType.Properties)
        .OfType<EdmProperty>()
        .Where(ep => ep.TypeUsage.Facets.Any(f => f.Name == "ConcurrencyMode" 
                && (EdmConcurrencyMode)f.Value == EdmConcurrencyMode.Fixed))
        .Select(ep => new 
                        { 
                            Type = ep.DeclaringType.Name,
                            Property = ep.Name,
                            DateType = ep.TypeUsage.EdmType.Name 
                        })
