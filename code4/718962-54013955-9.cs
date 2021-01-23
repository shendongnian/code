    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    namespace TestConsoleApp
    {
        class Program
        {
            public static void Main(string[] args)
            {
                var b = CountWeeksForYearsRange(1, 4000);
                var c = b.Where(a => a.Value != 53).ToDictionary(a=>a.Key, a=>a.Value);
            }
            static DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            static Calendar calendar = DateTimeFormatInfo.CurrentInfo.Calendar;
            private static int CountWeeksInYear(int year)
            {
                DateTime date = new DateTime(year, 12, 31);
                return calendar.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            }
            private static Dictionary<int,int> CountWeeksForYearsRange(int yearStart, int yearEnd)
            {
                Dictionary<int, int> rez = new Dictionary<int, int>();
                for (int i = yearStart; i <= yearEnd; i++)
                {
                    rez.Add(i, CountWeeksInYear(i));
                }
                return rez;
            }
        }
    }
