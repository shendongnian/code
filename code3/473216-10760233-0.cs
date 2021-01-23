    static void Main()
    {
        var setter = CreatePropertySetter(typeof (User), "Name");
        var obj = new User();
        setter(obj, "Fred");
    }
    public static Action<object, object> CreatePropertySetter(Type targetType, string propertyName)
    {
        var target = Expression.Parameter(typeof (object), "obj");
        var value = Expression.Parameter(typeof (object), "value");
        var property = targetType.GetProperty(propertyName);
        var body = Expression.Assign(
            Expression.Property(Expression.Convert(target, property.DeclaringType), property),
            Expression.Convert(value, property.PropertyType));
        var lambda = Expression.Lambda<Action<object, object>>(body, target, value);
        return lambda.Compile();
    }
