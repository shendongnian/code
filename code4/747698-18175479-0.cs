    [DebuggerHidden]
    public static void NotNull<T>(T value, Expression<Func<T>> exp) where T : class
    {
        if (value != null)
        {
            return;
        }
        var body = exp.Body as MemberExpression;
    
        if (body == null)
        {
            throw new ArgumentException("Wrongly formatted expression");
        }
    
        throw new ArgumentNullException(body.Member.Name);
    }
    
