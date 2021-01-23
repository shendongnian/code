    using System;
    using System.IO;
    using System.Globalization;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            TimeSpan x = new TimeSpan(0, 34, 23);
            TimeSpan y = new TimeSpan(4, 12, 31);
            Console.WriteLine(Divide(x, y)); // 0.13616 etc, i.e. 13%
        }
        
        public static double Divide(TimeSpan dividend, TimeSpan divisor)
        {
            return (double) dividend.Ticks / (double) divisor.Ticks;
        }
    }
