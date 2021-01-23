    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            ShowDates(new LocalDate(2012, 2, 28), new LocalDate(2012, 3, 6));
            ShowDates(new LocalDate(2012, 3, 5), new LocalDate(2012, 2, 29));
        }
        
        static void ShowDates(LocalDate start, LocalDate end)
        {
            // Previous is always strict - increment start so that
            // it *can* be the first day, then find the previous
            // Monday
            var current = start.PlusDays(1).Previous(IsoDayOfWeek.Monday);
            while (current <= end)
            {
                Console.WriteLine("{0} - {1}", current,
                                  current.Next(IsoDayOfWeek.Sunday));
                current = current.PlusWeeks(1);
            }
        }
    }
