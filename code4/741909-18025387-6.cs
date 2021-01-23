    public interface IRetailCalendarWeekDay
    {
        DateTime Date { get; } 
        int WeekDay { get; }
        int YearWeek { get; }
        int YearMonth { get; }
        int YearQuarter { get; }
        int Year { get; }
    }
