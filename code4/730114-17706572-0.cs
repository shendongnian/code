    public static IEnumerable<PropertyInfo> GetDifferentProperties<T>(T first, T second)
    {
        return typeof(T).GetProperties().Where(prop =>
            !object.Equals(prop.GetValue(first), prop.GetValue(second)));
    }
