    public interface IRetailCalendarWeekDay
    {
        DateTime Date { get; } 
        int WeekDay { get; } // 1 <= valid >= 7
        int Week { get; } // 1 <= valid >= 53
        int Month { get; } // 1 <= valid => 12
        int Quarter { get; } // 1 <= valid >= 4
        int Year { get; } // validate year range
    }
