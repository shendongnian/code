    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            // TZDB ID for Pacific time
            var zone = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
            // SystemClock implements IClock; you'd normally inject it
            // for testability
            var now = SystemClock.Instance.Now;
            
            var pacificNow = now.InZone(zone);        
            Console.WriteLine(pacificNow);
        }
    }
