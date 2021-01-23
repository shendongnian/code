    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Quater.GetFirstMonth(DateTime.Now.Month));
            Console.WriteLine(Quater.GetLastMonth(DateTime.Now.Month));
            Console.ReadLine();
        }
    }
    public static class Quater
    {
        public static string GetFirstMonth(int month)
        {
            if (month >= 1 && month <= 3) {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1);
            }
            if (month >= 4 && month <= 6) {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(4);
            }
            if (month >= 7 && month <= 9) {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(7);
            }
            if (month >= 10 && month <= 12) {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(10);
            }
            return string.Empty;
        }
        public static string GetLastMonth(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(3);
            }
            if (month >= 4 && month <= 6)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(6);
            }
            if (month >= 7 && month <= 9)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(9);
            }
            if (month >= 10 && month <= 12)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12);
            }
            return string.Empty;
        }
    }
