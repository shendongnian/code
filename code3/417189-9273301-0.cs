    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                var formatInfo = culture.NumberFormat;
                if (formatInfo.NumberDecimalSeparator != 
                    formatInfo.CurrencyDecimalSeparator)
                {
                    Console.WriteLine("{0}: {1} {2}",
                                      culture,
                                      formatInfo.NumberDecimalSeparator,
                                      formatInfo.CurrencyDecimalSeparator);
                }
            }
        }
    }
