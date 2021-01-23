    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double d = 123456.789;
                CultureInfo ci = new CultureInfo("de-DE");                        
                Console.WriteLine(d.ToString("N",ci));
                Console.ReadLine();
            }
        }
    }
