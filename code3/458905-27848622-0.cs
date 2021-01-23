    using System.Globalization;
    
    namespace TESTS
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //sample dates with correct week numbers in comments:
                string[] dats = new string[] { 
                     "2011-12-31","2012-01-01"  //1152
                    ,"2012-12-31","2013-01-01"  //1301
                    ,"2013-12-31","2014-01-01"  //1401
                    ,"2014-12-31","2015-01-01"  //1501
                    ,"2015-12-31", "2016-01-01" //1553
                };
    
                foreach (string str in dats)
                {
                    Console.WriteLine("{0} {1}", str, GetCalendarWeek(DateTime.Parse(str)));
                }
    
                Console.ReadKey();
        }
    
    
           public static int GetCalendarWeek(DateTime dat)
            {
                CultureInfo cult = System.Globalization.CultureInfo.CurrentCulture;
    
                // thursday of the same week as dat.
                // value__ for Sunday is 0, so I need (true, not division remainder %) mod function to have values 0..6 for monday..sunday
                // If you don't like casting Days to int, use some other method of getting that thursday
                DateTime thursday = dat.AddDays(mod((int)DayOfWeek.Thursday-1,7) - mod((int)dat.DayOfWeek-1,7));
                //week number for thursday:
                int wk = cult.Calendar.GetWeekOfYear(thursday, cult.DateTimeFormat.CalendarWeekRule, cult.DateTimeFormat.FirstDayOfWeek);
                // year adjustment - if thursday is in different year than dat, there'll be -1 or +1:
                int yr = dat.AddYears(thursday.Year-dat.Year).Year;
                    
                // return in yyww format:
                return 100 * (yr%100) + wk;
            }
    
            // true mod - helper function (-1%7=-1, I need -1 mod 7 = 6):
            public static int mod(int x, int m)
            {
                return (x % m + m) % m;
            }
    
    
    }
