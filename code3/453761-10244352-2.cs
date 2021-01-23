    static void Main(string[] args)
    {
        Foo foo1 = new Foo();
        foo1.SomethingHappened += new SomethingHappenedDelegate(Foo_SomethingHappened);
        Foo foo2 = new Foo();
        foo2.SomethingHappened += new SomethingHappenedDelegate(Foo_SomethingHappened); 
    }
    
    // we use same event handler for all SomethingHappened events
    static void Foo_SomethingHappened(object sender, string message, DateTime time)
    {
        Foo foo = sender as Foo; // now we get object, which raised event
        // and we can use message and time
    }
