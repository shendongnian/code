    private static DbQuery<T> EnumerateAllIncludes<T>(DbQuery<T> baseSet, Type type = null, string prefix = "") where T:class
    {
        if(type == null)
            return EnumerateAllIncludes(baseSet, typeof(T), prefix);
        var properties = type.GetProperties();
        foreach (var propertyInfo in properties)
        {
            var propertyType = propertyInfo.PropertyType;
            bool implementsICollection = propertyType.GetInterfaces()
                    .Any(x => x.IsGenericType &&
                    x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsICollection || (!propertyType.IsValueType && !propertyType.Equals(typeof(string))))
            {
                baseSet = baseSet.Include(prefix + propertyInfo.Name);
                EnumerateAllIncludes(baseSet, propertyType, prefix + propertyInfo.Name);
            }
        }
        return baseSet;
    }
