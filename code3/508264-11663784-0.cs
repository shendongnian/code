    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "MAY09";
            string pattern = "MMMyy";
            var culture = CultureInfo.InvariantCulture;
            DateTime value = DateTime.ParseExact(text, pattern, culture);
            Console.WriteLine(value.ToString("yyyy-MM-dd", culture));
        }
    }
