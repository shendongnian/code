    public interface IRetailCalendarWeekDay
    {
        DateTime Date { get; } 
        int WeekDay { get; } // 1 <= valid >= 7
        int YearWeek { get; } // 1 <= valid >= 53
        int YearMonth { get; } // 1 <= valid => 12
        int YearQuarter { get; } // 1 <= valid >= 4
        int Year { get; } // validate year range
    }
