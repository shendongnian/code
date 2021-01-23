    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            DateTime epoch = new DateTime(1, 1, 1, new PersianCalendar());
            // Prints 0622/03/21 00:00:00
            Console.WriteLine(FormatDateTimeAsGregorian(epoch));
        }
        
        public static string FormatDateTimeAsGregorian(DateTime input)
        {
            return input.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss",
                                  CultureInfo.InvariantCulture);
        }
    }
