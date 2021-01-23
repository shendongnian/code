    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            ShowAge(1988, 9, 6);
            ShowAge(1991, 3, 31);
            ShowAge(1991, 2, 25);
        }
        
        private static readonly PeriodType YearMonth =
            PeriodType.YearMonthDay.WithDaysRemoved();
        
        static void ShowAge(int year, int month, int day)
        {
            var birthday = new LocalDate(year, month, day);
            // For consistency for future readers :)
            var today = new LocalDate(2012, 2, 3);
            
            Period period = Period.Between(birthday, today, YearMonth);
            Console.WriteLine("Birthday: {0}; Age: {1} years, {2} months",
                              birthday, period.Years, period.Months);
        }
    }
