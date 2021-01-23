    public class Class1
    {
        public static void Main()
        {
            var dayList = new List<customMonthDay>{
                new customMonthDay{ Day = 11, Month = 1 },
                new customMonthDay{ Day = 15, Month = 3 },
                new customMonthDay{ Day = 25, Month = 5 },
                new customMonthDay{ Day = 1, Month = 9 }
            };
            var startDate = new DateTime( 2012, 1, 1 );
            var endDate = new DateTime( 2013, 7, 1 );
            var listYears = getYears(startDate, endDate);
            var includedDays = new List<customMonthDayYear>();
            foreach (var year in listYears)
            {
                foreach (var day in dayList)
                {
                    var candidateday = new customMonthDayYear { Year = year, Month = day.Month, Day = day.Day };
                    if (candidateday.ToDateTime() > startDate && candidateday.ToDateTime() < endDate)
                        includedDays.Add(candidateday);
                }
            }
            includedDays.ForEach(x => Console.WriteLine(x.ToDateTime().ToString()));
        }
        protected static List<int> getYears(DateTime start, DateTime end)
        {
            var years = new List<int>();
            int diff = end.Year - start.Year;
            for ( int i = 0; i <= diff; i++ )
            {
                years.Add( start.Year + i );
            }
            return years;
        }
        public class customMonthDay
        {
            public int Day { get; set; }
            public int Month { get; set; }
        }
        public class customMonthDayYear : customMonthDay
        {
            public int Year { get; set; }
            public DateTime ToDateTime()
            {
                return new DateTime(Year, Month, Day);
            }
        }
    }
