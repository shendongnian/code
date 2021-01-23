    class Program
    {
        public static readonly Dictionary<IEnumerable<int>, string> ErrorMessages =
        new Dictionary<IEnumerable<int>, string>
        {
            { Enumerable.Range(0,10), "Your frobinator was jamified" },
            { Enumerable.Range(10,10), "The grigbottle could not be doxicked" },
            { Enumerable.Range(20,10), "Ouch! That hurt!" },
            { Enumerable.Range(30,10), "The input was not palendromic" },
            // etc
        };
        static void Main(string[] args)
        {
            int error = 2;
            string message = ErrorMessages
                .Where(m => m.Key.Contains(error))
                .FirstOrDefault().Value;
            Console.WriteLine(message); // "Your frobinator was jamified"
        }
    }
