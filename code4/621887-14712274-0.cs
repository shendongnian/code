    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        int weeknum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                e.Date.Date,
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
        );
        TableCell cell = ((DayRenderEventArgs)e).Cell;
        cell.Controls.Add(new LiteralControl("weekmum:"+weeknum.ToString()));
    }
