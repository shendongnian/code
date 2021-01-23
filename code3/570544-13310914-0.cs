    void Foo()
    {
        Foo(DateTime.Now);
    }
    
    void Foo(DateTime dt)
    {
        //do something
    }
    //you can't use optional parameters here because DateTime.Now is not a constant
    void Foo(DateTime dt = DateTime.Now)  //compile error
    {
        //do something
    }
