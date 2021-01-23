    static void Main()
    {
        var setter = CreatePropertySetter<User,string>("Name");
        var obj = new User();
        setter(obj, "Fred");
    }
    public static Action<TType, TValue> CreatePropertySetter<TType, TValue>(string propertyName)
    {
        var target = Expression.Parameter(typeof (TType), "obj");
        var value = Expression.Parameter(typeof (TValue), "value");
        var property = typeof(TType).GetProperty(propertyName);
        var body = Expression.Assign(
            Expression.Property(target, property),
            value);
        var lambda = Expression.Lambda<Action<TType, TValue>>(body, target, value);
        return lambda.Compile();
    }
