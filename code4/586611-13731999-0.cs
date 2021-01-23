    public void someMethod(Foo f)
    {
        // Overload 1
    }
    
    public void someMethod(IFoo f)
    {
        // Overload 2
    }
    
    Foo x = new Foo();
    someMethod(x); // Matches overload 1
    IFoo x = new Foo();
    someMethod(x); // Matches overload 2
