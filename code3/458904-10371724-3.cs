    using System;
    using NodaTime;
    using NodaTime.Calendars;
    
    public class Test
    {
        static void Main()
        {
            LocalDate date = new LocalDate(2012, 1, 1);
            IWeekYearRule rule = WeekYearRules.Iso;
            Console.WriteLine($"WeekYear: {rule.GetWeekYear(date)}"); // 2011
            Console.WriteLine($"WeekOfWeekYear: {rule.GetWeekOfWeekYear(date)}"); // 52
        }
    }
