    public List<DateTime> availableDates;
    protected void Page_Load(object sender, EventArgs e)
    {
        availableDates = (from d in sb.GetDaysWithAvailableSlotsByLocation(3)
                                         select d.Date).ToList<DateTime>();
        DateTime firstAvailable = availableDates.Min();
        calSlotBooker.VisibleDate = firstAvailable;
    } 
