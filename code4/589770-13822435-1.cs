    using (var context = new ModelContainer())
    {
        var container =     context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
        var entitySet =     container.BaseEntitySets[someEntityName];
        var navProperties = set.ElementType.Members.Where(member => member.BuiltInTypeKind == BuiltInTypeKind.NavigationProperty).Select(member => member.Name).ToList();
    }
