    namespace ConsoleApplication12
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var items = new []{ 1, 2, 3, 4, 5 };
                items.PrintArray();
            }
        }
    
        static class ArrayExtensions
        {
            public static void PrintArray<T>(this IEnumerable<T> elements)
            {
                foreach (var element in elements)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
