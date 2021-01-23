    //enum for various patterns
    public enum OccurrenceRate
    {
        Weekly,
        Fortnightly,
        Monthly
    }
    public static List<DateTime> GetOccurrences(DateTime startDate, DateTime endDate, OccurrenceRate rate)
    {
        List<DateTime> occurrences = new List<DateTime>();
    
        var nextDate = startDate;
    
        while (true)
        {
            if (nextDate <= endDate)
            {
                occurrences.Add(nextDate);
            }
            else
            {
                break;
            }
    
            switch (rate)
            {
                case OccurrenceRate.Weekly:
                {
                    nextDate = nextDate.AddDays(7);
                    break;
                }
                case OccurrenceRate.Fortnightly:
                {
                    nextDate = nextDate.AddDays(14);
                    break;
                }
                case OccurrenceRate.Monthly:
                {
                    nextDate = nextDate.AddMonths(1);
                    break;
                }
            }
        }
        return occurrences;
    }
