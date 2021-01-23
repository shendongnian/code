    class Program
    {
        static void Main(string[] args)
        {
            Range.Switch(10)
                .Case(0, 3, () => Console.WriteLine("Between 0 and 3"))
                .Case(3, 7, () => Console.WriteLine("Between 3 and 7"))
                .Default(() => Console.WriteLine("Something else"));
        }
    }
