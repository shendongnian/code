    public static IEnumerable<Outlook.AppointmentItem> GetCalendarItemsOnDate(this Outlook.MAPIFolder pCalendarFolder, DateTime pDateToRead)
    {
        var filter = "( [Start] >= '" + pDateToRead.ToString("MM/dd/yyyy") + "'" + " AND " + "  [End]  < '" +     pDateToRead.AddDays(1).ToString("MM/dd/yyyy") + "' )";
        pCalendarFolder.Items.IncludeRecurrences = false;
        var outlookCalendarItems = pCalendarFolder.Items.Restrict(filter);
        outlookCalendarItems.IncludeRecurrences = false;
        var allItem = string.Empty;
        foreach (Outlook.AppointmentItem item in outlookCalendarItems)
        {
            if (item.IsRecurring)
            {
                continue;
            }
            yield return item;
        }
    }
