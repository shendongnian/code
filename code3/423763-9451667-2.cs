    using System;
    
    class Test
    {
        static void Main()
        {
            ShowDates(new DateTime(2012, 2, 28), new DateTime(2012, 3, 6));
            ShowDates(new DateTime(2012, 2, 1), new DateTime(2012, 2, 29));
        }
        
        static void ShowDates(DateTime start, DateTime end)
        {
            // In DateTime, 0=Sunday
            var daysToSubtract = ((int) start.DayOfWeek + 6) % 7;
            var current = start.AddDays(-daysToSubtract);        
            
            while (current <= end)
            {
                Console.WriteLine("{0} - {1}", current, current.AddDays(6));
                current = current.AddDays(7);
            }
        }
    }
