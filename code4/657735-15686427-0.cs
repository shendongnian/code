    public static Expression<Func<Calendar, CalendarViewModel>> CalendarExpression()
    {
        return c => new CalendarViewModel
        {
            ID = c.ID,
            Name = c.Name,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            AcademicYear = c.AcademicYear
        };
    }
    var calendarExpr = Match.CalendarExpression();
    IQueryable<CalendarViewModel> callendars =
        (from call in (new KYTCDataContext()).Calendars
         where call.AcademicYear == id
         select call)
        .Select(calendarExpr);
