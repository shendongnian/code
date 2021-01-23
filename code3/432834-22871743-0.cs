    public static string GetTimeString(Decimal dHours)
    {
        DateTime dTime = new DateTime().AddHours(dHours);
        return dTime.ToString("HH:mm:ss");    // HH: 24h or hh: 12h
    }
