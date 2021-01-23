    private List<Outlook.AppointmentItem> GetOutlookAppointments(DateTime start, DateTime end) {
		var outlook = new Microsoft.Office.Interop.Outlook.Application();
		var app = outlook.Application;
		var appSession = app.Session;
		var calendar = appSession.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
		string filter = String.Format("[Start] >= {0} And [End] < {1}", start.ToString("ddddd h:nn AMPM"), end.ToString("ddddd h:nn AMPM"));
		var items = calendar.Items;
		items.Restrict(filter);
		items.IncludeRecurrences = true;
    
		Outlook.AppointmentItem appointment;
		var appointments = new List<Outlook.AppointmentItem>();
		foreach (var item in items)
		{
			appointment = item as Outlook.AppointmentItem;
			if (appointment != null && !appointment.AllDayEvent && (appointment.BusyStatus != Outlook.OlBusyStatus.olOutOfOffice))
			{
				if (appointment.IsRecurring)
				{
					AddReoccuringAppointments(appointments, start, end, appointment);
				}
				else if (appointment.Start >= start && appointment.End < end)
				{	
					appointments.Add(appointment);
				}
			}
		}
    }
    private static void AddReoccuringAppointments(List<Outlook.AppointmentItem> appointments, DateTime start, DateTime end, Outlook.AppointmentItem appointment)
    {
        Outlook.RecurrencePattern rp = appointment.GetRecurrencePattern();
        if (rp.PatternStartDate >= end || rp.PatternEndDate <= start) { return; }
        if (rp.PatternStartDate > start)
        {
            start = rp.PatternStartDate;
        }
        if (rp.PatternEndDate < end)
        {
            end = rp.PatternEndDate;
        }
    
        var exceptions = GetExceptions(rp, start, end);
    
        Outlook.AppointmentItem recur = null;
        Outlook.Exception exception = null;
        for (DateTime cur = new DateTime(start.Year, start.Month, start.Day, appointment.Start.Hour, appointment.Start.Minute, 0); cur <= end; cur = cur.AddDays(1))
        {
            if ((((int)rp.DayOfWeekMask) & (int)Math.Pow(2,(int)cur.DayOfWeek)) == 0) { continue; }
            exception = exceptions.FirstOrDefault(e => e.OriginalDate.Date == cur.Date);
            if (exception == null)
            {
                recur = rp.GetOccurrence(cur);
            }
            else if (!exception.Deleted)
            {
                recur = exception.AppointmentItem;
            }
    
            if (recur != null)
            {
                appointments.Add(recur);
            }
        }
    }
    
    private static List<Outlook.Exception> GetExceptions(Outlook.RecurrencePattern rp, DateTime start, DateTime end)
    {
        List<Outlook.Exception> exceptions = new List<Outlook.Exception>();
        foreach (Outlook.Exception e in rp.Exceptions)
        {
            if (e.OriginalDate >= start && e.OriginalDate < end)
            {
                exceptions.Add(e);
            }
        }
        return exceptions;
    }
