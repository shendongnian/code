    public static Func<S, T> BuildGetAccessor<S, T>(Expression<Func<S, T>> propertySelector)
    {
        return propertySelector.GetPropertyInfo().GetGetMethod().CreateDelegate<Func<S, T>>();
    }
    public static Action<S, T> BuildSetAccessor<S, T>(Expression<Func<S, T>> propertySelector)
    {
        return propertySelector.GetPropertyInfo().GetSetMethod().CreateDelegate<Action<S, T>>();
    }
    // a generic extension for CreateDelegate
    public static T CreateDelegate<T>(this MethodInfo method) where T : class
    {
        return Delegate.CreateDelegate(typeof(T), method) as T;
    }
    public static PropertyInfo GetPropertyInfo<S, T>(this Expression<Func<S, T>> propertySelector)
    {
        var body = propertySelector.Body as MemberExpression;
        if (body == null)
            throw new MissingMemberException("something went wrong");
        return body.Member as PropertyInfo;
    }
