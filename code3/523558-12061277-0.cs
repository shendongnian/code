    [Fact]
    public void Test()
    {
        Ninject.Bind<Func<MyClass.Item[]>>().ToProvider<Func<MyClass.Item[]>>(new CallbackProvider<Func<MyClass.Item[]>>((ctx) => () => MyClass.GetInitialState(new[] { "A", "B" })));
        var myClass = Ninject.Get<MyClass>();
    }
    
    [Fact]
    public void Test2()
    {
        Ninject.Bind<Func<MyClass.Item[]>>().ToConstant<Func<MyClass.Item[]>>(() => MyClass.GetInitialState(new[] { "A", "B", "C" }));
        var myClass = Ninject.Get<MyClass>();
    }
