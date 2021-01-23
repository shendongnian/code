    private readonly static Dictionary<Type, EntitySetBase> _mappingCache 
           = new Dictionary<Type, EntitySetBase>();
    private ObjectContext _ObjectContext
    {
        get { return (this as IObjectContextAdapter).ObjectContext; }
    }
    
    private EntitySetBase GetEntitySet(Type type)
    {
        type = GetObjectType(type);
        if (_mappingCache.ContainsKey(type))
            return _mappingCache[type];
    
        string baseTypeName = type.BaseType.Name;
        string typeName = type.Name;
    
        ObjectContext octx = _ObjectContext;
        var es = octx.MetadataWorkspace
                        .GetItemCollection(DataSpace.SSpace)
                        .GetItems<EntityContainer>()
                        .SelectMany(c => c.BaseEntitySets
                                        .Where(e => e.Name == typeName 
                                        || e.Name == baseTypeName))
                        .FirstOrDefault();
    
        if (es == null)
            throw new ArgumentException("Entity type not found in GetEntitySet", typeName);
        _mappingCache.Add(type, es);
    
        return es;
    }
    
    internal String GetTableName(Type type)
    {
        EntitySetBase es = GetEntitySet(type);
    
        //if you are using EF6
        return String.Format("[{0}].[{1}]", es.Schema, es.Table);
        
        //if you have a version prior to EF6
        //return string.Format( "[{0}].[{1}]", 
        //        es.MetadataProperties["Schema"].Value, 
        //        es.MetadataProperties["Table"].Value );
    }
