    using System.Globalization; // for Calendar
    using System.Linq; // for GroupBy
    ...
    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    Calendar cal = dfi.Calendar
    var groups = data.GroupBy(x => cal.GetWeekOfYear(
        x.timestamp, dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
