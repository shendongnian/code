    public static IEnumerable<Type> GetDerivedTypes(this Type baseType, Assembly assembly)
    {
        var types = from t in assembly.GetTypes()
                    where t.IsSubclassOf(baseType)
                    select t;
        return types;
    }
