    public static class Extensions
    {
        public static string MonthToString(this int value)
        {
            return (value >= 1 && value <= 12) ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(value) : "";
        }
    }
    
    class Program
    {
        static void Main()
        {
            dynamic foo = 123;
            Console.WriteLine(foo.MonthToString());
        }
    }
