    public static IQueryable SelectDynamic(this IQueryable source, IEnumerable<string> fieldNames)
    {
        Dictionary<string, PropertyInfo[]> sourceProperties = new Dictionary<string, PropertyInfo[]>();
        foreach (var propertyPath in fieldNames)
        {
            var props = propertyPath.Split('.');
            var name = props.Last();
            PropertyInfo[] infos;
            if (sourceProperties.TryGetValue(name, out infos))
                name = string.Join("", props);
            sourceProperties[name] = source.ElementType.GetDeepProperty(props);
        }
        Type dynamicType = LinqRuntimeTypeBuilder.GetDynamicType(sourceProperties.ToDictionary(x => x.Key, x => x.Value.Last().PropertyType));
        ParameterExpression sourceItem = Expression.Parameter(source.ElementType, "t");
        IEnumerable<MemberBinding> bindings = dynamicType.GetFields()
            .Select(p => Expression.Bind(p, sourceItem.MakePropertyExpression(sourceProperties[p.Name]))).OfType<MemberBinding>();
        Expression selector = Expression.Lambda(Expression.MemberInit(
            Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);
        MethodCallExpression selectExpression = Expression.Call(typeof(Queryable), "Select", new Type[] { source.ElementType, dynamicType }, Expression.Constant(source), selector);
        return Expression.Lambda(selectExpression).Compile().DynamicInvoke() as IQueryable;
    }
    public static PropertyInfo[] GetDeepProperty(this Type type, params string[] props)
    {
        List<PropertyInfo> list = new List<PropertyInfo>();
        foreach (var propertyName in props)
        {
            var info = type.GetProperty(propertyName);
            type = info.PropertyType;
            list.Add(info);
        }
        return list.ToArray();
    }
    public static Expression MakePropertyExpression(this ParameterExpression sourceItem, PropertyInfo[] properties)
    {
        Expression property = sourceItem;
        foreach (var propertyInfo in properties)
            property = Expression.Property(property, propertyInfo);
        return property;
    }
