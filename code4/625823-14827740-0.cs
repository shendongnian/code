    IDictionary<DateTime, HolyDay> holyDays;
    HolyDay holyDay;
    if (holyDays.TryGetValue(workDay.Date, out holyDay))
    {
        Print(workDay.Date + " is " + holyDay.Description);
    }
    else
    {
        Print(workDay.Date + " is no holyDay");
    }
