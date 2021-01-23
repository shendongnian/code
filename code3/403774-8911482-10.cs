    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static readonly long _ticksIn30Mins = TimeSpan.FromMinutes(30).Ticks; 
            static void Main(string[] args)
            {
                WriteDateString(new DateTime(2012, 01, 18, 09, 45, 11, 152));
                WriteDateString(new DateTime(2012, 01, 18, 12, 15, 11, 999));
                WriteDateString(new DateTime(2012, 01, 18, 12, 00, 00, 000));
                Console.ReadLine();
            }
            private static void WriteDateString(DateTime dateTime)
            {
                Console.WriteLine("Before: {0}, After: {1}", dateTime, GetRoundedTime(dateTime));
            }
            private static DateTime GetRoundedTime(DateTime inputTime)
            {
                long currentTicks = inputTime.Ticks; 
                var rounded = new DateTime(currentTicks.RoundUp(_ticksIn30Mins));
                if (rounded == inputTime)
                {
                    rounded = new DateTime(rounded.Ticks + _ticksIn30Mins);
                }
                return rounded;
            } 
        }
        public static class ExtensionMethods
        {
            public static long RoundUp(this long i, long toTicks)
            {
                return (long)(Math.Round(i / (double)toTicks, MidpointRounding.AwayFromZero)) * toTicks;
            }
        }  
    }
