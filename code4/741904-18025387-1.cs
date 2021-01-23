    public class RetailCalendarWeekDay
    {
        int Year { get; set; } // validate year range
        int Month { get; set; } // 1 <= valid => 12
        int Quarter { get; set; } // 1 <= valid >= 4
        int Week { get; set; } // 1 <= valid >= 53
        int WeekDay { get; set; } // 1 <= valid >= 7
        DateTime Date { get; set; } // no setter should ever *update* the record!!
    }
