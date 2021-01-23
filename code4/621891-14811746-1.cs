    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            eventsDayView.DataLoad(DateTime.Now);
            calendar.SelectedDate = DateTime.Now;
            calendar.TodaysDate = DateTime.Now;
            calendar.VisibleDate = DateTime.Today;
            addWeekNumberColumn();
        }
    }
    private void addWeekNumberColumn()
    {
        // Get the date shown in the calendar control
        DateTime curMonth = calendar.VisibleDate;
        // Find first day of the current month
        curMonth = Convert.ToDateTime(curMonth.Year.ToString() + "-" + curMonth.Month.ToString() + "-01");
        // Build javascript
        string jscript = "<script type='text/javascript'> addWkColumn('" + calendar.ClientID + "', " + getISOWeek(curMonth).ToString() + ");</script>";
        // Add script to page for execution of addWkColumn javascript function
        Page.ClientScript.RegisterStartupScript(this.GetType(), "AddWeeknumbers", jscript);
    }
    // Helper function to find ISO week
    private int getISOWeek(DateTime day)
    {
        return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(day, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
    protected void calendar_OnVisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        calendar.VisibleDate = e.NewDate;
        addWeekNumberColumn();
    }
