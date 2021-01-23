    using System;
    
    class Test
    {
        static void Main()
        {
            Foo<Action<>>();
        }
        
        static void Foo<T>()
        {
            Console.WriteLine(typeof(T));
        }
    }
