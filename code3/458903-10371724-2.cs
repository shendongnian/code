    using System;
    using NodaTime;
    
    public class Test
    {
        static void Main()
        {
            LocalDate date = new LocalDate(2012, 1, 1);
            Console.WriteLine($"WeekYear: {date.WeekYear}");             // 2011
            Console.WriteLine($"WeekOfWeekYear: {date.WeekOfWeekYear}"); // 52
        }
    }
