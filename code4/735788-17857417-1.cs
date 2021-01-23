    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "2013-07-03T02:16:03.000+01:00";
            string pattern = "yyyy-MM-dd'T'HH:mm:ss.FFFK";
            DateTimeOffset dto = DateTimeOffset.ParseExact
                (text, pattern, CultureInfo.InvariantCulture);
            Console.WriteLine(dto);
        }
    }
