    public void Foo(SomeObjectType theObject)
    {
        int initialValue = theObject.SomeProperty;
        theObject.SomeProperty = 25;
        Console.Out.WriteLine("Property is:" + theObject.SomeProperty);
    
        // reset object.
        theObject.SomeProperty = initialValue;
        Console.Out.WriteLine("Property oringinal value is:" + theObject.SomeProperty);
    }
