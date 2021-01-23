    using System;
    using System.Linq;
    using System.Xml.Linq;
    using NodaTime;
    using NodaTime.Text;
    
    public class Test
    {
        static void Main()
        {
            string text = "Sat Apr 28 2012 11:00:00 GMT-0400 (Eastern Daylight Time)";
            ZonedDateTime parsed = Parse(text);
            Console.WriteLine(parsed);
        }
        
        static readonly LocalDateTimePattern LocalPattern =
            LocalDateTimePattern.CreateWithInvariantInfo("ddd MMM d yyyy HH:mm:ss");
        
        // Note: Includes space before GMT for convenience later
        static readonly OffsetPattern OffsetPattern =
            OffsetPattern.CreateWithInvariantInfo("' GMT'+HHmm");
    
        static ZonedDateTime Parse(string text)
        {
            int gmtIndex = text.IndexOf(" GMT");
            int zoneIndex = text.IndexOf(" (");
            // TODO: Validation that these aren't -1 :)
            
            string localText = text.Substring(0, gmtIndex);
            string offsetText = text.Substring(gmtIndex, zoneIndex - gmtIndex);
            
            var localResult = LocalPattern.Parse(localText);
            var offsetResult = OffsetPattern.Parse(offsetText);
            
            // TODO: Validate that both are successful
            
            var fixedZone = DateTimeZone.ForOffset(offsetResult.Value);        
            return localResult.Value.InZoneStrictly(fixedZone);
        }
    }
