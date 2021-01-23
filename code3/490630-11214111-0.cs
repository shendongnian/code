    using System;
    using System.Globalization;
    
    class Program
    {
        public static void Main()
        {
            var french = new CultureInfo("FR-fr");
            var info = french.DateTimeFormat;
            foreach (var dayName in info.DayNames)
            {
                // dimanche, lundi etc
                Console.WriteLine(dayName);
            }
        }    
    }
