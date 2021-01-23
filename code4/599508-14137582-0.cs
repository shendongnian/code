    public static class TypeHelper
    {
        public static Type FindBaseClassWith(this Type typeLeft, Type typeRight)
        {
            if(typeLeft == null || typeRight == null) return null;
    
            return typeLeft
                    .GetClassHierarchy()
                    .Intersect(typeRight.GetClassHierarchy())
                    .Where(type => !type.IsInterface)
                    .FirstOrDefault();
        }
        
        public static Type FindInterfaceWith(this Type typeLeft, Type typeRight)
        {
            if(typeLeft == null || typeRight == null) return null;
        
            return typeLeft
                    .GetInterfaces()
                    .Where(type => type.IsInterface)
                    .Intersect(
                        typeRight
                            .GetInterfaces()
                            .Where(type => type.IsInterface))
                                .FirstOrDefault();   
        }
    
        // get classes hierarchy
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
    }
