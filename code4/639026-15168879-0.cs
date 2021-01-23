    using System;
    
    class Program
    {
        enum Foo
        {
            Bar = 1,
            Baz = 2
        }
        
        static void Main()
        {
            int[] ints = new int[] { 1, 2 };
            Foo[] foos = (Foo[]) (object) ints;
            foreach (var foo in foos)
            {
                Console.WriteLine(foo);
            }
        }
    }
