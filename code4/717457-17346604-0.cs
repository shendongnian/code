    List<DateTime> AvailableDates {get; set;}
    protected void Page_Load(object sender, EventArgs e)
    {
        AvailableDates = (from d in sb.GetDaysWithAvailableSlotsByLocation(3)
                                         select d.Date).ToList<DateTime>();
        DateTime firstAvailable = AvailableDates.Min();
        calSlotBooker.VisibleDate = firstAvailable;
    } 
    protected void calSlotBooker_DayRender(object sender, DayRenderEventArgs e)
    {
        if (!(AvailableDates.Contains(e.Day.Date)) || (e.Day.Date.DayOfWeek == DayOfWeek.Saturday) || (e.Day.Date.DayOfWeek == DayOfWeek.Sunday))
        {
            e.Cell.BackColor = System.Drawing.Color.Silver;
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = "Unavailable";
        }
    }
