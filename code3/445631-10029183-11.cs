    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            DateTime local1 = DateTime.Parse("2012-10-28T00:30:00.0000000Z");
            DateTime local2 = DateTime.Parse("2012-10-28T01:30:00.0000000Z");
            
            DateTime utc1 = TimeZoneInfo.ConvertTimeToUtc(local1);
            DateTime utc2 = TimeZoneInfo.ConvertTimeToUtc(local2);
            Console.WriteLine(utc1);
            Console.WriteLine(utc2);
    
            DateTime utc3 = local1.ToUniversalTime();
            DateTime utc4 = local2.ToUniversalTime();
            Console.WriteLine(utc3);
            Console.WriteLine(utc4);
        }
    }
