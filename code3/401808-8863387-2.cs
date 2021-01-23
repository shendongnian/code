    public class Class2
    {
        public static string Input { get; set; }
        public static string ExtractInput(string line)
        {
            return TextMethods.ExtractArgument(line);
        }
    }
