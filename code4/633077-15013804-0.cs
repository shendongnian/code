    using System;
    
    class Test
    {
        static void Main()
        {
            // Don't be fooled - this really is the Pacific time zone,
            // not just standard time...
            var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var utcNow = DateTime.UtcNow;
            var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
            
            Console.WriteLine(pacificNow);
        }
    }
