    static void Main()
    {
        Log();
        IEnumerable<int> data = GetData();
        while (data.Any())
        {
            var value = data.First();
            Console.WriteLine("\t\tFound:{0}", value);
            var found = data.Where(i => i == value);
            data = data.Except(found);
        }
    }
    static IEnumerable<int> GetData()
    {
        Log();
        return new[] { 1, 2, 3, 4, 5 };
    }
