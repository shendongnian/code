    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (!"KonNy".StartsWith("Kon", false, culture))
                {
                    Console.WriteLine(culture);
                }
            }
        }
    }
