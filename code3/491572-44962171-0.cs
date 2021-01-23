    var bads = new []  // COMPILER ERROR
    {
        Foo
    };
    var goods = new Action[]  // NO COMPILER ERROR
    {
        Foo
    };
    //...
    public void Foo() { }
