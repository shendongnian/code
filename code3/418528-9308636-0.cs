    using System;
    using NodaTime;
    using NodaTime.Text;
    public class Test
    {
        static void Main(string[] args)
        {
            var pattern = LocalDateTimePattern.CreateWithInvariantInfo
                  ("MMM dd, yyyy HH:mm:ss tt");
            LocalDateTime start = pattern.Parse("Nov 06, 2011 01:59:58 AM").Value;
            LocalDateTime end = pattern.Parse("Nov 06, 2011 01:00:00 AM").Value;
            
            DateTimeZone zone = DateTimeZone.ForId("America/Chicago");
            
            // Where this is ambiguous, pick the earlier option
            ZonedDateTime zonedStart = zone.AtEarlier(start);
            // Where this is ambiguous, pick the later option
            ZonedDateTime zonedEnd = zone.AtLater(start);
            
            Duration duration = zonedEnd.ToInstant() - zonedStart.ToInstant();
            
            // Prints 01:00:00
            Console.WriteLine(duration.ToTimeSpan());
        }        
    }
