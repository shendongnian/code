    public static IEnumerable<PropertyInfo> GetOrderedProperties(Type type)
    {
        Dictionary<Type, int> lookup = new Dictionary<Type, int>();
    
        int count = 0;
        lookup[type] = count++;
        Type parent = type.BaseType;
        while (parent != null)
        {
            lookup[parent] = count;
            count++;
            parent = parent.BaseType;
        }
    
        return type.GetProperties()
            .OrderByDescending(prop => lookup[prop.DeclaringType]);
    }
