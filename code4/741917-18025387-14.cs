    public interface IRetailTime
    {
        DateTime Date { get; } // does not have "time" info ("00:00:00")
        int DayHour { get; }
        int WeekDay { get; }
        int YearWeek { get; }
        int YearMonth { get; }
        int YearQuarter { get; }
        int Year { get; }
    }
