        static void Main()
        {
            var list = new List<meter_reading>
                           {
                               new meter_reading {Date = new DateTime(2000, 2, 15), T1 = 2, T2 = 3},
                               new meter_reading {Date = new DateTime(2000, 2, 10), T1 = 4, T2 = 5},
                               new meter_reading {Date = new DateTime(2000, 3, 15), T1 = 2, T2 = 3},
                               new meter_reading {Date = new DateTime(2000, 3, 15), T1 = 5, T2 = 4}
                           };
                var sum = list
                .GroupBy(x => GetFirstDayInMonth(x.Date))
                .Select(item => new meter_reading
                                    {
                                        Date = item.Key,
                                        T1 = item.Sum(x => x.T1),
                                        T2 = item.Sum(x => x.T2),
                                    }).ToList();
        }
        private static DateTime GetFirstDayInMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Date.Year, dateTime.Date.Month, 1);
        }
