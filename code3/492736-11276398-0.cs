    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> items = new List<int> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> evens = items.Where(y => isEven(y));
            int count = evens.Count();
            Console.WriteLine("count = {0}", count);
            int first = evens.First();
            Console.WriteLine("first = {0}", first);
        }
        private static bool isEven(int y)
        {
            Console.Write(y + ": ");
            
            bool result = y % 2 == 0;
    
            Console.WriteLine(result);    
            return result;
        }
    }
