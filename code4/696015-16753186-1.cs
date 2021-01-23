    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            LocalDate start = new LocalDate(2013, 3, 3);
            LocalDate end = new LocalDate(2013, 5, 25);
            
            // Defaults to years, months and days - but you can change
            // that by specifying a PeriodUnits value.
            Period period = Period.Between(start, end);
            Console.WriteLine("{0} years, {1} months, {2} days",
                              period.Years, period.Months, period.Days);
        }
    }
