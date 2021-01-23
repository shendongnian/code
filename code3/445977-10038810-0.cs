    public static void avgDate(List<DateTime> Dates) {
        long totalTicks = 0;
        string avgticks = "";
        TimeSpan days = new TimeSpan();
    
        for (int i = 1; i < Dates.Count; i++)
        {
            days += (Dates[i] - Dates[i-1]);
        }
        Console.WriteLine(days.TotalDays);
        Console.ReadLine();`
