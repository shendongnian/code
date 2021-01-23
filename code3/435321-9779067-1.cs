    [AttributeUsage(AttributeTargets.Method)]
    class PropertyExpressionAttribute : Attribute
    { }
    …
    [PropertyExpression]
    static void Foo<T>(Expression<Func<SomeType, T>> expr)
    { }
    …
    Foo(x => x.P);   // OK
    Foo(x => x.M()); // error
    Foo(x => 42);    // error
