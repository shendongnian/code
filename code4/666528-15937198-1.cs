    using (var db = new MyDbContext())
    {
        var objectContext = ((IObjectContextAdapter)db).ObjectContext;
        var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
        var dependents = ((EntitySet)(set)).ForeignKeyDependents;
        var principals = ((EntitySet)(set)).ForeignKeyPrincipals;
        var navigationProperties = ((EntityType)(set.ElementType)).NavigationProperties;
        // and e.g. for many-to-many (there is more for other types)
        ManyToManyReferences = navigationProperties.Where(np =>
            np.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many &&
            np.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
            .Select(np => Extensions.CreateLambdaExpression<TEntity>(np.Name))
            .ToList();
    }
