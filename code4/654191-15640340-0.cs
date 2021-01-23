    using System;
    using System.Collections.Generic;
    namespace RandomScheduler
    {
        class Program
        {
            public static Random R = new Random();
            static void Main()
            {
                var now = DateTime.Now;
                var random = new Random((int)now.Ticks);
                const int windowOfHours = 12;
                const int minimumTimeApartInHours = 2;
                const int numOfEvents = 5;
                // let's start the window 8 AM
                var start = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0, 0);
                // let's end 12 hours later
                var end = start.AddHours(windowOfHours);
                var prev = null as DateTime?;
                const int hoursInEachSection = windowOfHours / numOfEvents;
                var events = new List<DateTime>();
                for (var i = 0; i < numOfEvents; i++)
                {
                    // if there is a previous value
                    // let's at least start 2 hours later
                    if (prev.HasValue)
                        start = prev.Value.AddHours(minimumTimeApartInHours);
                    DateTime? @event;
                    do
                    {
                        // pick a random double, so we get minutes involved
                        var hoursToAdd = random.NextDouble()*hoursInEachSection;
                        // let's add the random hours to the start
                        // and we get our next event
                        @event = start.AddHours(hoursToAdd);
                    // let's make sure we don't go past the window
                    } while (@event > end); 
                    prev = @event;
                    events.Add(@event.Value);
                }
                Console.WriteLine(string.Join("\n", events));
                Console.ReadLine();
            }
        }
    }
