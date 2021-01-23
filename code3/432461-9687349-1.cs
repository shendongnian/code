    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            var calendar = new TaiwanCalendar();
            var date = new DateTime(101, 2, 29, calendar);
            var culture = CultureInfo.CreateSpecificCulture("zh-TW");
            culture.DateTimeFormat.Calendar = calendar;       
            
            Console.WriteLine(date.Year); // 2012
            Console.WriteLine(date.ToString(culture)); // 101/2/29 [etc]
            Console.WriteLine(date.ToString("d", culture)); // 101/2/29
        }
    }
