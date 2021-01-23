    // Do a few cheap checks and ensure that current month is the last month of 
    // quarter before computing the third friday of month
    if (Cur.DayOfWeek == DaysOfWeek.Friday && Cur.Day > 14 && Cur.Month % 3 == 0) {
        var Friday = new DateTime(Cur.Year, Cur.Month, 15);
            Friday.AddDays((5 - (int)Friday.DayOfWeek + 7) % 7);
        if (Cur.Day == Friday.Day)
            return true;
    }
