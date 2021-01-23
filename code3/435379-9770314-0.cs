    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("test.txt");
            var result = input
                .Select(
                    line => Regex.Matches(line, @"\d+")
                                 .OfType<Match>()
                                 .Select(m => m.Groups[0].Value)
                );
            foreach (string[] numbers in result)
            {
                Console.WriteLine(string.Join(",", numbers));
            }
        }
    }
