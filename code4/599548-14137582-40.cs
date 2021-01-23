    public static Type FindEqualTypeWith(this Type typeLeft, Type typeRight)
    {
        if(typeLeft == null || typeRight == null) return null;
 
        var commonBaseClass = typeLeft.FindBaseClassWith(typeRight) ?? typeof(object);
        
        return commonBaseClass.Equals(typeof(object))
                ? typeLeft.FindInterfaceWith(typeRight)
                : commonBaseClass;
    }
 
    public static Type FindBaseClassWith(this Type typeLeft, Type typeRight)
    {
        if(typeLeft == null || typeRight == null) return null;
 
        return typeLeft
                .GetClassHierarchy()
                .Intersect(typeRight.GetClassHierarchy())
                .FirstOrDefault(type => !type.IsInterface);
    }
    
    public static Type FindInterfaceWith(this Type typeLeft, Type typeRight)
    {
        if(typeLeft == null || typeRight == null) return null;
    
        return typeLeft
                .GetInterfaceHierarchy()
                .Intersect(typeRight.GetInterfaceHierarchy())
                .FirstOrDefault();   
    }
 
    public static IEnumerable<Type> GetInterfaceHierarchy(this Type type)
    {
        if(type.IsInterface) return new [] { type }.AsEnumerable();
    
        return type
                .GetInterfaces()
                .OrderByDescending(current => current.GetInterfaces().Count())
                .AsEnumerable();
    }
 
    public static IEnumerable<Type> GetClassHierarchy(this Type type)
    {
        if(type == null) yield break;
        
        Type typeInHierarchy = type;
        
        do
        {
            yield return typeInHierarchy;
            typeInHierarchy = typeInHierarchy.BaseType;
        }
        while(typeInHierarchy != null && !typeInHierarchy.IsInterface);
    }
