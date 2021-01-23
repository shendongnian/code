    using System;
    using NodaTime;
    
    public class Test
    {
        static void Main(string[] args)
        {
            LocalDate start = new LocalDate(2010, 6, 19);
            LocalDate end = new LocalDate(2013, 4, 11);
            Period period = Period.Between(start, end,
                                           PeriodUnits.Years | PeriodUnits.Days);
            
            Console.WriteLine("Between {0} and {1} are {2} years and {3} days",
                              start, end, period.Years, period.Days);
        }
    }
