    class Program
    {
        public static DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        public static DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        static void Main(string[] args)
        {
            var date1 = new DateTime(2012, 10, 10);
            var date2 = new DateTime(2012, 12, 31);
            Console.Out.WriteLine(date1.ToShortDateString() + "\t" + LastDayOfMonthFromDateTime(date1).ToShortDateString());
            while (LastDayOfMonthFromDateTime(date1) < date2)
            {
                date1 = date1.AddMonths(1);
                Console.Out.WriteLine(FirstDayOfMonthFromDateTime(date1).ToShortDateString() + "\t" + LastDayOfMonthFromDateTime(date1).ToShortDateString());
            }
            Console.ReadLine();
        }
    }
