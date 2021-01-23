    using System;
    using NodaTime;
    
    class Test
    {
        static readonly Instant Start = Instant.FromUtc(2002, 10, 17, 0, 0);
        static readonly Instant End = Instant.FromUtc(2012, 10, 17, 0, 0);
        
        static void Main()
        {
            var provider = DateTimeZoneProviders.Bcl;
            foreach (var id in provider.Ids)
            {
                var zone = provider[id];
                ShowTransitions(zone);
            }        
        }
        
        static void ShowTransitions(DateTimeZone zone)
        {
            Console.WriteLine("{0}:", zone.Id);
            var zoneInterval = zone.GetZoneInterval(Start);
            while (zoneInterval.End < End)
            {
                Console.WriteLine("{0} - {1}: {2}",
                                  zoneInterval.Start,
                                  zoneInterval.End,
                                  zoneInterval.WallOffset);
                zoneInterval = zone.GetZoneInterval(zoneInterval.End);
            }
        }
    }
