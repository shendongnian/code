    static public IEnumerable<DateTime> EachDay(DateTime Startdate, DateTime EndDate)
        {
            for (var day = Startdate.Date; day.Date <= EndDate.Date; day = day.AddDays(1))
                yield return day;
        }
