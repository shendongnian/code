    public Foo()
    {
        // ...
        init();
    }
    protected Foo(bool connect)
    {
        // ...
        if (connect) {
            init();
        }
    }
