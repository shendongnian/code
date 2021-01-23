    static void Main(string[] args)
    {
        Foo foo = new Foo();
        foo.SomethingHappened += new SomethingHappenedDelegate(Foo_SomethingHappened);            
    }
    
    // this method should be: void MethodName()
    static void Foo_SomethingHappened()
    {
        // you notified, that something happened
    }
