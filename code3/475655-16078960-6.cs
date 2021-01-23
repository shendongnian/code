    Func<S, T> Getter;
    Action<S, T> Setter;
    PropertyInfo Property;
    public void Initialize(Expression<Func<S, T>> propertySelector)
    {
        var body = propertySelector.Body as MemberExpression;
        if (body == null)
            throw new MissingMemberException("something went wrong");
        Property = body.Member as PropertyInfo;
        //approaches:
        //Getter = s => (T)Property.GetValue(s, null);
        //Getter = memberSelector.Compile();
        //ParameterExpression inst = Expression.Parameter(typeof(S));
        //Getter = Expression.Lambda<Func<S, T>>(Expression.Property(inst, Property), inst).Compile();
        //var inst = Expression.Parameter(typeof(S));
        //Getter = Expression.Lambda<Func<S, T>>(Expression.Call(inst, Property.GetGetMethod()), inst).Compile();
        //Getter = (Func<S, T>)Delegate.CreateDelegate(typeof(Func<S, T>), Property.GetGetMethod());
        //Setter = (s, t) => Property.SetValue(s, t, null);
        //var val = Expression.Parameter(typeof(T));
        //var inst = Expression.Parameter(typeof(S));
        //Setter = Expression.Lambda<Action<S, T>>(Expression.Call(inst, Property.GetSetMethod(), val),
        //                                         inst, val).Compile();
        //Setter = (Action<S, T>)Delegate.CreateDelegate(typeof(Action<S, T>), Property.GetSetMethod());
    }
    //Actual calls (tested under loop):
    public T Get(S instance)
    {
        //direct invocation:
        //return (T)Property.GetValue(instance, null);
       //calling the delegate:
       //return Getter(instance);
    }
    public void Set(S instance, T value)
    {
        //direct invocation:
        //Property.SetValue(instance, value, null);
       //calling the delegate:
       //Setter(instance, value);
    }
