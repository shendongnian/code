    private IFoo foo;
    public Bar()
    {
        // Production code uses the real thing
        this.foo = new Foo();
    }
    public Bar(IFoo foo)
    {
        // Test code uses a passed-in object, likely a mock
        this.foo = foo;
    }
    public DoSomething()
    {
        foo.DoSomething();
    }
