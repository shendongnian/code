    public class Week
    {
        public Week(int weekOfYear, int year)
        {
            WeekOfYear = weekOfYear;
            Year = year;
        }
        public int WeekOfYear { get; private set; }
        public int Year { get; private set; }
    }
    public IEnumerable<Week> Next10Weeks(DateTime startDate)
    {
        DateTime tempDate = startDate;
        for (int i = 0; i < 10; i++)
        {
            //add one to first parameter if you want the 1-indexed week instead of 0 indexed
            yield return new Week(tempDate.DayOfYear % 7, tempDate.Year);
            tempDate.AddDays(7);
        }
    }
