    class Program
    {
        static void Main()
        {
            var items = new object[] { 1, 2, 3, 4 };
            var items2 = new object[] { 2, 3, 4, 5 };
            new ToList(items, items2).Value.ForEach(x => Console.WriteLine(x));
            Console.Read();
        }
    }
