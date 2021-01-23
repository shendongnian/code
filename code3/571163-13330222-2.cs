    public static DateTime GetEdate(string _Fdate)
    {
        DateTime fdate = Convert.ToDateTime(_Fdate);
        GregorianCalendar gcalendar = new GregorianCalendar();
        DateTime eDate = pcalendar.ToDateTime(
               gcalendar.GetYear(fdate),
               gcalendar.GetMonth(fdate),
               gcalendar.GetDayOfMonth(fdate),
               gcalendar.GetHour(fdate),
               gcalendar.GetMinute(fdate),
               gcalendar.GetSecond(fdate), 0);
        return eDate;
    }
