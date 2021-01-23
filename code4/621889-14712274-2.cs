    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        int weeknum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                e.Day.Date,
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
        );
        e.Cell.Controls.Add(new LiteralControl(string.Format("({0})", weeknum)));
    }
