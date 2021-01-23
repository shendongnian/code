    using System;
    
    class Test
    {    
        static void Main()        
        {
            var id = "W. Australia Standard Time"; // Perth
            var zone = TimeZoneInfo.FindSystemTimeZoneById(id);
            var utc1 = new DateTime(2005, 12, 31, 15, 59, 0, DateTimeKind.Utc);
            var utc2 = new DateTime(2005, 12, 31, 16, 00, 0, DateTimeKind.Utc);
            var utc3 = new DateTime(2005, 12, 31, 23, 59, 0, DateTimeKind.Utc);
            var utc4 = new DateTime(2006, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Console.WriteLine(zone.GetUtcOffset(utc1));
            Console.WriteLine(zone.GetUtcOffset(utc2));
            Console.WriteLine(zone.GetUtcOffset(utc3));
            Console.WriteLine(zone.GetUtcOffset(utc4));
        }
    } 
