    using System;
    using System.Globalization;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                CultureInfo cult = CultureInfo.InvariantCulture;
    
                string txt = "Mon Apr 22 07:56:21 +0000 2013";
                string format = "ddd MMM dd hh:mm:ss zzz yyyy";
                DateTime dt = DateTime.ParseExact(txt, format, cult);
    
            }
        }
    }
