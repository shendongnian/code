    class Program
    {
        static void Main(string[] args)
        {
            var list = new[] {"Liverpool - 1", 
                              "Liverpool - 11",
                              "Liverpool - 123",
                              "Liverpool - 342",
                              "Liverpool - 2"};
            foreach (var x in list.OrderBy(s => Int32.Parse(Regex.Match(s, @"- (\d*)").Groups[1].Value)))
                Console.WriteLine(x);
        }
    }
