    class Program
    {
        static void Main(string[] args)
        {
            var stringWithLongWords = "Here's a text with tooooooooooooo long words";
            var trimmed = TrimLongWords(stringWithLongWords, 6);
        }
        private static string TrimLongWords(string stringWithLongWords, int p)
        {
            return Regex.Replace(stringWithLongWords, String.Format(@"[\w]{{{0},}}", p), m =>
            {
                return m.Value.Substring(0, p-1) + "...";
            });
        }
    }
