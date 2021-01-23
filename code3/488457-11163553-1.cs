    List<Type> entityTypes = new List<Type>();
    
    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (InheritsFromValidationDef(type))
        {
            IMappingSource mappingSource = (IMappingSource)Activator.CreateInstance(type);
            entityTypes.Add(mappingSource.GetMapping().EntityType);
        }
    }
    private static bool InheritsFromValidationDef(Type type)
    {
        Type baseType = type.BaseType;
        bool result = baseType != null && 
                      baseType.IsGenericType &&
                      baseType.GetGenericTypeDefinition() == typeof(ValidationDef<>);
        return result;
    }
