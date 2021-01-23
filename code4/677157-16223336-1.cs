    public static IEnumerable<Type> GetDerivedTypes(this Type baseType, Assembly assembly)
    {
        if (baseType == null) { throw new ArgumentNullException("baseType"); }
        if (assembly == null) { throw new ArgumentNullException("assembly"); }
        var types = from t in assembly.GetTypes()
                    where t.IsSubclassOf(baseType)
                    select t;
        return types;
    }
