    using System;
    
    public class Generic<T>
    {
        // Of course we wouldn't normally have public fields, but...
        public static int Foo;
    }
    
    public class Test
    {
        public static void Main()
        {
            Generic<string>.Foo = 20;
            Generic<object>.Foo = 10;
            Console.WriteLine(Generic<string>.Foo); // 20
        }
    }
