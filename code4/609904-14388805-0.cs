    class Program
    {
        static void Main(string[] args)
        {
            string[] x = "abc|||dev".Split("|||");
        }
    }
    public static class StringExtensions
    {
        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] { separator }, StringSplitOptions.None);
        }
    }
