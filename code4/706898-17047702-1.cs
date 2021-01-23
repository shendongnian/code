    static class Program
    {
        private static readonly Dictionary<string, string> _myDict = new Dictionary<string, string>
        {
            { "test", "test" },
            { "test2", "test2" }
        };
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
