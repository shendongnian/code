    void Main()
    {
        var foobar = new FooBar();
        foreach(IObject obj in new IObject[]{ new ObjectType1(), new ObjectType2()})
        {
            foobar.Foo((dynamic)obj);
        }   
        // Output:
        //  Type 1
        //  Type 2
    }
    
    class IObject
    {
    }
    
    class ObjectType1 : IObject
    {
    }
    
    class ObjectType2 : IObject
    {
    }
    
    class FooBar
    {
        public void Foo (ObjectType1 obj) {
            Console.WriteLine("Type 1");
        }
        public void Foo (ObjectType2 obj) {
            Console.WriteLine("Type 2");
        }
    }
