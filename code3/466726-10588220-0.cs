    public T Foo<T>(T obj)
    {
        var variable = GetTFromFooElse();
        return variable; 
    }
    
----------
    public dynamic Foo()
    {
        var variable = GetSomethingFromFooElse();
        return variable;
    }
    
