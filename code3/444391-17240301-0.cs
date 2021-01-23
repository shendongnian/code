    namespace Playground.Sandbox
    {
        using System.Collections.Concurrent;
        using System.Threading.Tasks;
    
        public static class Program
        {
            public static void Main()
            {
                var items = new[] { "Foo", "Bar", "Baz" };
                var bag = new ConcurrentBag<string>();
                Parallel.ForEach(items, bag.Add);
            }
        }
    }
