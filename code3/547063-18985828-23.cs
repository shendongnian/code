    internal String GetTableName(Type type)
    {
        type = GetObjectType(type);
        string baseTypeName = type.BaseType.Name;
        string typeName = type.Name;
        ObjectContext octx = _ObjectContext;
        var es = octx.MetadataWorkspace
                        .GetItemCollection(DataSpace.SSpace)
                        .GetItems<EntityContainer>()
                        .SelectMany(c => c.BaseEntitySets
                                        .Where(e => e.Name == typeName || e.Name == baseTypeName))
                        .FirstOrDefault();
        if (es == null)
            throw new ArgumentException("Entity type not found in GetTableName", typeName);
        return String.Format("[{0}].[{1}]", es.Schema, es.Table);
    }
