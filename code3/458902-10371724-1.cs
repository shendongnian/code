    using System;
    using NodaTime;
    
    public class Test
    {
        static void Main()
        {
            LocalDate date = new LocalDate(2012, 1, 1);
            Console.WriteLine("WeekYear: {0}", date.WeekYear);             // 2011
            Console.WriteLine("WeekOfWeekYear: {0}", date.WeekOfWeekYear); // 52
        }
    }
