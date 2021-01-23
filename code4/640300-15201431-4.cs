    static class FooPopulator
    {
        public static void PopulateValues(Foo foo)
        {
            foo.Prop1 = "Hello";
            foo.Prop2 = "World";
        }
    }
    
    var foo = new Foo();
    FooPopulator.PopulateValues(foo);
