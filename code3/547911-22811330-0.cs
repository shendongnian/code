    public static Items GetAppointmentsInRange(MAPIFolder mAPIFolder, DateTime startTime, DateTime endTime)
    {
        string filter = string.Format("[Start] >= '{0}' AND [End] <= '{1}'", startTime.ToString("g"), endTime.ToString("g"));
        Items calItems = mAPIFolder.Items.Restrict(filter);             
        calItems.Sort("[Start]", Type.Missing);
        return calItems;
    }
    
    public static MAPIFolder GetTimeTrackingCalendar()
    {
        MAPIFolder result = null;
        MAPIFolder calendars = (MAPIFolder)outlook.ActiveExplorer().Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
        for (int i = 1; i <= calendars.Folders.Count; i++)
        {
            if (calendars.Folders[i].Name != Constants.TIME_TRACKING_CALENDAR) continue;
            result = calendars.Folders[i];
            break;
        }
        return result;
    }
    
    public static Items FindDeveloperTimeForDates(DateTime beginDate, DateTime endDate)
    {
        return OutlookApp.GetAppointmentsInRange(OutlookApp.GetTimeTrackingCalendar(), beginDate, endDate);
        
    }
