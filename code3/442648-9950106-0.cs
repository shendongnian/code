    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var inclusions = new[] { "Pacific", "Central", "Mountain", "Eastern" };
            foreach (var zone in TimeZoneInfo.GetSystemTimeZones()
                          .Where(zone => inclusions.Any(x => zone.Id.Contains(x))))
            {
                Console.WriteLine(zone.Id);
            }
        }
    }
