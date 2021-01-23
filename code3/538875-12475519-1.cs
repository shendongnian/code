    public static double GetBusinessDays(DateTime startD, DateTime endD) 
    {
        double calcBusinessDays =
            1 + ((endD-startD).TotalDays * 6 -
            (startD.DayOfWeek-endD.DayOfWeek) * 2) / 7;
        if ((int)startD.DayOfWeek == 0) calcBusinessDays --;
        return calcBusinessDays;
    }
    public static DateTime AddWorkDaysToStartDate(DateTime startD, double businessDays)
    {
        int DoW = (int)startD.DayOfWeek;
        double temp = businessDays + DoW + 1;
        if (DoW != 0) temp --;
        DateTime calcendD = startD.AddDays(
        Math.Floor(temp / 6)*2-DoW + temp
            - 2* Convert.ToInt32(temp % 6 == 0)) ;
    }
