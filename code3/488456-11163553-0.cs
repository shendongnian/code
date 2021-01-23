    List<Type> entityTypes = new List<Type>();
    
    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (type.BaseType == typeof(ValidationDef<>))
        {
            IMappingSource mappingSource = (IMappingSource)Activator.CreateInstance(type);
            entityTypes.Add(mappingSource.GetMapping().EntityType);
        }
    }
