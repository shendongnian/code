    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var numList = new List<string>(){"0", "-6e-5", "78.56238", "05.56", "0.5E9", "-45,000.56", "", ".56", "10.4852,64"};
                numList.ForEach(num =>
                {
                    // If we use NumberStyles.Float => -45,000.56 is invalid
                    if (decimal.TryParse(num, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                    {
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine(num + " is not a valid number");
                    }
                });
    
            }
        }
    }
