    public T InvokePropertyExpression<T>(object obj, string propertyName)
    {
        return Expression.Lambda<Func<T>>(Expression.Property(
                   Expression.Constant(obj), propertyName)).Compile()();
    }
