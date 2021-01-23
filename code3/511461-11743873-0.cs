    class Program
    {
        private static void Main(string[] args)
        {
            var splited = Split("asd fds 1.4#3").ToArray();
        }
        public static IEnumerable<string> Split(string text)
        {
            StringBuilder result = new StringBuilder();
            foreach (var ch in text)
            {
                if (char.IsLetter(ch))
                {
                    result.Append(ch);
                }
                else
                {
                    yield return result.ToString();
                    result.Clear();
                    yield return ch.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
