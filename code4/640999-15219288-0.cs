    static class Program
    {
        public static DateTime ToDateTime(this string datestring)
        {
            return DateTime.Parse(datestring);
        }
        static void Main(string[] args)
        {
            DateTime date = "12/12/12".ToDateTime();
        }
    }
