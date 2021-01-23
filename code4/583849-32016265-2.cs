    var test = new SomeClass();
    var proxy = RuntimeProxy.Create(test, t =>
    {
        // cross-cut here
    
        return t.Invoke();          // invoke the actual call
    });
    
    var res = proxy.Mul(3, 4);      // method with return value
    proxy.SetValue(2);              // void method, setting some property
    var val = proxy.Val;            // property access
