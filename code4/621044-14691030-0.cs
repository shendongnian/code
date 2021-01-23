    class Program
    {
        static void Main(string[] args)
        {
            string s = "test Title cAsE";
            s = s.ToTitleCase();
            Console.Write(s);
        }
    }
    public static class StringExtensions
    {
        public static string ToTitleCase(this string inputString)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputString);
        }
    }
