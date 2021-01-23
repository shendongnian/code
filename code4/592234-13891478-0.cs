    using System;
    using System.Globalization;
    
    namespace Programs
    {
        public class Program
        {      
            public static void Main(string[] args)
            {
                string str = "11/15/2012 00:00:00";
                DateTime dt = DateTime.ParseExact(str, "MM/dd/yyyy hh:mm:ss", new CultureInfo("af-ZA"));
                Console.WriteLine(dt.ToString());
            }
        }
    }
