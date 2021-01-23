    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            DateTime epoch = new DateTime(1, 1, 1, new HijriCalendar());
            Console.WriteLine(epoch.Year);  // 622
            Console.WriteLine(epoch.Month); // 7
            Console.WriteLine(epoch.Day);   // 18
        }
    }
