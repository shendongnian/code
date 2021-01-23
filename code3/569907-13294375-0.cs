    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            var bcl = DateTimeZoneProviders.Bcl["Eastern Standard Time"];
            var tzdb = DateTimeZoneProviders.Tzdb["America/New York"];
            
            ShowTransitions(bcl);
            ShowTransitions(tzdb);
        }
        
        static void ShowTransitions(DateTimeZone zone)
        {
            Console.WriteLine("Transitions for {0}", zone.Id);
            Instant start = Instant.FromUtc(1960, 1, 1, 0, 0);
            Instant end = Instant.FromUtc(1965, 1, 1, 0, 0);
            var interval = zone.GetZoneInterval(start);
            while (interval.Start < end)
            {
                Console.WriteLine(interval.Start);
                interval = zone.GetZoneInterval(interval.End);
            }
            Console.WriteLine();
        }
    }
