    void NotifyOfPropertyChanging<TProperty>(Expression<Func<TProperty>> property)
    {
        var memberExpression = (MemberExpression) property.Body;
        var prop = (PropertyInfo) memberExpression.Member;
        Func<TProperty> accessor;
        if (!TypedAccessorCache<TProperty>.Cache.TryGetValue(prop, out accessor))
        {
            accessor = property.Compile();
            TypedAccessorCache<TProperty>.Cache[prop] = accessor;
        }
        var value = accessor();
        // ...
    }
    static class TypedAccessorCache<TProperty>
    {
        public static readonly IDictionary<PropertyInfo, Func<TProperty>> Cache =
            new Dictionary<PropertyInfo, Func<TProperty>>();
    }
