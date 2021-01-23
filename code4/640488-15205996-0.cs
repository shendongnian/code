    [MyAttribute(BindMethod = "GetBinding")]
    public string Foo1 { get; set; }
    public Expression GetBinding()
    {
        Expression<Func<MyModel, string>> expr = m => m.Foo2;
        return expr;
    }
