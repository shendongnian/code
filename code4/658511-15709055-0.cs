    public void Foo(MyInterface x)
    {
    }
    [Test]
    public void EnsureAssemblyIsLoaded()
    {
        Foo(this);
        ... assertions ...
    }
