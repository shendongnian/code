    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            // TZDB ID for Pacific time
            DateTimeZone zone = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
            // SystemClock implements IClock; you'd normally inject it
            // for testability
            Instant now = SystemClock.Instance.Now;
            
            ZonedDateTime pacificNow = now.InZone(zone);        
            Console.WriteLine(pacificNow);
        }
    }
