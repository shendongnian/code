    using System;
    using System.Globalization;
    
    class Program {
        static void Main(string[] args) {
            var ci = CultureInfo.GetCultureInfo("ml-IN");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            var ts = new TimeSpan(0, 2, 9);
            var dt = new DateTime(Math.Abs(ts.Ticks));
            Console.WriteLine(dt.ToString("HH:mm:ss"));
            Console.ReadLine();
        }
    }
