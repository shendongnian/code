    class Program
    {
        static void Main()
        {
            var items = new[] { 1, 2, 3, 4 };
            var items2 = new[] { 2, 3, 4, 5 };
            var where = new Where<int>(items, items2).Value;
            new ToList<int>(where).Value.ForEach(x => Console.WriteLine(x));
            Console.Read();
        }
    }
