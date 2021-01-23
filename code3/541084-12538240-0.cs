    using System;
    using System.Linq;
    
    class Foo {}
    
    class Program
    {
        public static void Main()
        {
            var foos = new[] { new Foo(), new Foo() };
            var ordered = foos.OrderBy(x => x);
            Console.WriteLine(ordered.Count());
        }
    }
