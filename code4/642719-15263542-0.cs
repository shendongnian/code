    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var bookingStartsAndEnds = new List<DateTime>()
                                               {
                                                   DateTime.Parse("1999-02-01 13:50:00"),
                                                   DateTime.Parse("1999-02-03 13:50:00"),
                                                   DateTime.Parse("1999-02-04 13:05:00"),
                                                   DateTime.Parse("1999-02-04 13:15:00"),
                                               };
                var bookedHours = bookingStartsAndEnds
                    // order by the date ascending
                    .OrderBy(dt => dt)
                    // select only the "firsts" of the tuples
                    .Where((dt, i) => i%2 == 0)
                    // select the first + the next
                    .Select((dt, i) => Tuple.Create<DateTime, DateTime?>(dt, bookingStartsAndEnds.ElementAtOrDefault((i*2) + 1)))
                    // filter not-matching-end (the list must contain even number of items only!)
                    .Where(t => t.Item2 != null)
                    // calculate the time-difference between end-date and start-date and get all hours
                    .Select(t => (t.Item2.Value - t.Item1).TotalHours)
                    // sum them up
                    .Sum(); 
                Console.WriteLine("{0:0.00} hours dude! this will be expensive...", bookedHours);
                Console.Read();
            }
        }
    }
