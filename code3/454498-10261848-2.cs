    private List<FieldInfo> GetConstants(Type type)
    {
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
             BindingFlags.Static | BindingFlags.FlattenHierarchy);
        
        return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList()
    }
    
