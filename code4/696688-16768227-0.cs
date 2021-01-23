    public Foo()
    {
        ConnectCode();
    }
    protected Foo(bool connect)
        : this()
    {
        if(connect)
            ConnectCode();
    }
