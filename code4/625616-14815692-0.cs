    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "2/17/2013 12:00:00 AM";
            string format = "M/d/yyyy h:mm:ss tt";
            DateTime value = DateTime.ParseExact(text, format,
                                                 CultureInfo.InvariantCulture,
                                                 DateTimeStyles.None);
            Console.WriteLine(value);
        }
    }
