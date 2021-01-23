    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            DateTime value;
            if (DateTime.TryParseExact("4/27/2011 12:00:00 AM",
                                       "M/d/yyyy h:mm:ss tt",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out value))
            {
                Console.WriteLine(value);
            }
        }
    }
