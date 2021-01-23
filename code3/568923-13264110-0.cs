    using System;
    using System.Globalization;
    using System.Threading;
    internal class Program
    {
        private static void Main(string[] args)
        {      
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            const string input = "interesting";
            
            bool comparison = input.ToUpper() == "INTERESTING";
    
            Console.WriteLine("These things are equal: " + comparison);
            Console.ReadLine();
        }
    }
