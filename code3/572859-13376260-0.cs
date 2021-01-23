    class Bar
    {
        internal IFoo Foobar { get; set; }
    }
    void main()
    {
        Bar bar = new Bar();
        bar.Foobar = new Foo1();
        IFoo instance1 = bar.Foobar; // Ok.
        Foo1 instance2 = (Foo1)bar.Foobar; // Bad practice, but ok.
        Foo2 instance3 = (Foo2)bar.Foobar; // Bad practive plus an exception.
        Foo2 instance3 = (Foo2)(Foo1)bar.Foobar; // Still an exception.
        Foo2 instance3 = (Foo2)(IFoo)(Foo1)bar.Foobar; // Still a fail.
    }
