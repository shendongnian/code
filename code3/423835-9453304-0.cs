    public Foo()
    {
        Id = ComputeId();
    }
    
    public Foo(string name)
        : this()
    {
        Name = name;
    }
