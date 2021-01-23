    class Program
    {
        const string FindReplace = "cat";
        static void Main(string[] args)
        {
            var input = "The CAT sat on the mat as a cat.";
            var result = Regex
                .Replace(
                input,
                "(?<=.*)" + FindReplace + "(?=.*)",
                m =>
                {
                    return "{" + m.Value.ToUpper() + "}";
                },
                RegexOptions.IgnoreCase);
            Console.WriteLine(result);
        }
    }
