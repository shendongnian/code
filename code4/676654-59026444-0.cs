    using System;
    using System.Globalization;
    
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double x = 567892.98789;
                CultureInfo someCulture = new CultureInfo("da-DK", false);
    
                // 10 means left-padded = right-alignment
                Console.WriteLine(String.Format(someCulture, "{0:N} denmark", x));
                Console.WriteLine("{0,10:N} us", x); 
    
                // watch out rounding 567,893
                Console.WriteLine(String.Format(someCulture, "{0,10:N0}", x)); 
                Console.WriteLine("{0,10:N0}", x);
    
                Console.WriteLine(String.Format(someCulture, "{0,10:N5}", x));
                Console.WriteLine("{0,10:N5}", x);
    
    
                Console.ReadKey();
    
            }
        }
    }
