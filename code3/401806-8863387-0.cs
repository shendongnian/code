    public class Class2
    {
        public static Input { get; set; }
        public static string ExtractInput(string line)
        {
            return TextMethods.ExtractArgument(line);
        }
    }
