    using System;
    using System.Globalization;
    
    static class Test
    {
        static void Main()
        {
            string text = "Fri, 18 Dec 2009 9:38 am PST";
            DateTime parsed = TrimZoneAndParse(text);
            Console.WriteLine(parsed);
        }
        
        static DateTime TrimZoneAndParse(string text)
        {
            int lastSpace = text.LastIndexOf(' ');
            if (lastSpace != -1)
            {
                text = text.Substring(0, lastSpace);
            }
            return DateTime.ParseExact(text,
                "ddd, dd MMM yyyy h:mm tt",
                CultureInfo.InvariantCulture);
        }
    }
