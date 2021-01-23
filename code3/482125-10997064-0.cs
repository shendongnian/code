    using System;
    using NodaTime;
    
    class Program
    {    
        public static void Main()
        {
            var local = new LocalDateTime(2012, 10, 28, 1, 30, 0);
            var zone = DateTimeZone.ForId("Europe/London");
            var mapping = zone.MapLocal(local);
            
            Console.WriteLine(mapping.Count); // 2
            Console.WriteLine(mapping.First()); // 1.30 with offset +1
            Console.WriteLine(mapping.Last()); // 1.30 with offest +0
        }    
    }
