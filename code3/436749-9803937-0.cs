    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            var parsed = DateTime.ParseExact("2012-03-15 12:49:23",
                                             "yyyy-MM-dd HH:mm:ss",
                                             CultureInfo.InvariantCulture,
                                             DateTimeStyles.AssumeUniversal |
                                             DateTimeStyles.AdjustToUniversal);
            var dtOffset = new DateTimeOffset(parsed);
            var output = dtOffset.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz",
                                           CultureInfo.InvariantCulture);
            Console.WriteLine(output);
        }                   
    }
