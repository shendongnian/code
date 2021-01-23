    public static void AddValue<T>(
        this SerializationInfo source,
        Expression<Func<T>> memberExpression)
    {
        Func<T> valFunc = memberExpression.Compile();
        T val = valFunc();
 
        source.AddValue(val, memberExpression);
    }
    public static void AddValue<T>(
        this SerializationInfo source,
        T val,
        Expression<Func<T>> memberExpression)
    {
        MemberExpression body = memberExpression.Body as MemberExpression;
        string name = body.Member.Name;
 
        source.AddValue(name, val, typeof(T));
    }
