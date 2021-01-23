    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            var date = DateTime.ParseExact("2012-09-30T23:00:00.0000000Z",
                                           "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'",
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.AssumeUniversal |
                                           DateTimeStyles.AdjustToUniversal);
            Console.WriteLine(date);
            Console.WriteLine(date.Kind);
        }
    }
