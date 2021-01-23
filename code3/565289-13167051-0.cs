    using System;
    
    class Test
    {
        static void Main()
        {
            DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime decemberUtc = new DateTime(2012, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            ConvertToMountainTime(octoberUtc);
            ConvertToMountainTime(decemberUtc);
        }
        
        static void ConvertToMountainTime(DateTime utc)
        {
            DateTime mountain = TimeZoneInfo.ConvertTimeBySystemTimeZoneId
                (utc, "Mountain Standard Time");
            
            Console.WriteLine("{0} (UTC) = {1} Mountain time", utc, mountain);
        }
    }
