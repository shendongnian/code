    public static class FooExtensions
    {
        public static void ApplyFooDefaults(this Foo1 foo1)
        {
            foo1.Name = "Foo 1";
    
            Console.WriteLine(foo1);
        }
    
        public static void ApplyFooDefaults(this Foo2 foo2)
        {
            foo2.Name = "Foo 2";
            foo2.Description = "SomeDefaultDescription";
    
            Console.WriteLine(foo2);
        }
    
        public static void ApplyFooDefaults(this Foo3 foo3)
        {
            foo3.Name = "Foo 3";
            foo3.MaxSize = Int32.MaxValue;
    
            Console.WriteLine(foo3);
        }
    
        public static void ApplyFooDefaults(this Foo4 foo4)
        {
            foo4.Name = "Foo 4";
            foo4.MaxSize = 99999999;
            foo4.EnableCache = true;
    
            Console.WriteLine(foo4);
        }
    
        public static void ApplyFooDefaults(this FooBase unhandledFoo)
        {
            unhandledFoo.Name = "Unhandled Foo";
            Console.WriteLine(unhandledFoo);
        }
    }
