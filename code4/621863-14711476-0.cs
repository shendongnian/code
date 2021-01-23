    public static PropertyInfo GetPropertyByDataMemberName<T>(string dataMemberName)
        where T : BaseClass
    {
        return typeof(T)
            .GetProperties()
            .Where(z => Attribute.IsDefined(z, typeof(DataMemberAttribute)))
            .Single(z => ((DataMemberAttribute)Attribute.GetCustomAttribute(z, typeof(DataMemberAttribute))).Name == dataMemberName);
    }
    // Shortcut overload for properties on BaseClass.
    public static PropertyInfo GetPropertyByDataMemberName(string dataMemberName)
    {
        return GetPropertyByDataMemberName<BaseClass>(dataMemberName);
    }
