    class Program
    {
        private const string StripNonNumbersRegex = @"[^\d]";
        static void Main(string[] args)
        {
            var number = Format("88 88-88)8.8(88");
        }
    
        public static string Format(string number)
        {
            return Regex.Replace(number, StripNonNumbersRegex, string.Empty);
        }
    }
