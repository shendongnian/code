    using System;
    
    class FooBase
    {
        public bool Do(int p) { return false; }
    }
    
    class Foo<T> : FooBase
    {
        public bool Do(T p) { return true; }
    }
    
    class Test
    {
        static void Main()
        {
            FooBase foo1 = new Foo<int>();
            Console.WriteLine(foo1.Do(10)); // False
            
            Foo<int> foo2 = new Foo<int>();
            Console.WriteLine(foo2.Do(10)); // True
        }
    }
