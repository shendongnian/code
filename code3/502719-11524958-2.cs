    using System;
    class Foo {
        static void Main() {
            int i = 0;
            Action increment = delegate { ++i; };
            
            Console.WriteLine(i);
            
            ++i;
            Console.WriteLine(i);
            
            increment();
            Console.WriteLine(i);
            
            ++i;
            Console.WriteLine(i);
            
            increment();
            Console.WriteLine(i);
        }
    }
