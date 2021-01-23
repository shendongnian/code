    public static List<DateTime> GetFortnightlyOccurrences(DateTime startDate)
    {
        List<DateTime> occurrences = new List<DateTime>();
        var nextDate = startDate;
        var endDate = startDate.AddDays(5 * 7);
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
            nextDate = nextDate.AddDays(14);
        }
        return occurrences;
    }
