    using System;
    using System.Globalization;
    using System.Threading;
    
    namespace ConsoleApplication18
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine(Strings.DisplayName);
    
                Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.GetCultureInfo("nb-NO");
                Console.WriteLine(Strings.DisplayName);
            }
        }
    }
