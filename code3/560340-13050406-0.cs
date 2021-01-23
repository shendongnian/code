    string name = "MyNamespace.Customer";
    
    Type targetType = Type.GetType(name);
    
    Type genericType = typeof(GenericRepository<>).MakeGenericType( targetType );
    
    object instance = Activator.CreateInstance(genericType);
