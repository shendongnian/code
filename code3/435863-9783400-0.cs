    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            double d = 123456.789;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
            
            Console.WriteLine(d.ToString("N3", culture)); // 123.456,789
        }                   
    }
