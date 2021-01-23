    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First call");
            Foo(1, 2, 3);
            Console.WriteLine("Second call");
            Foo(new int[] { 1, 2, 3 });
        }
        
        static void Foo(params object[] values)
        {
            foreach (object x in values)
            {
                Console.WriteLine(x.GetType().Name);
            }
        }
    }
