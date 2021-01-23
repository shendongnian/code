    class Program
    {
        static void Main(string[] args)
        {
          
            var str = "asdfasd";
            var trimmed = str.MySubString(2);
            Console.WriteLine(trimmed);
            Console.ReadLine();
        }
        
    }
    public static class Helper
    {
        public static string MySubString(this String value, int length)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= length
            ? value.Substring(0, length)
            : value;
        }
    }
