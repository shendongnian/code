    public static List<DateTime> GetFortnightlyOccurrences(DateTime startDate)
    {
        List<DateTime> occurrences = new List<DateTime>();
        var nextDate = startDate;
        while (true)
        {
            if (nextDate <= startDate.AddDays(5 * 7))
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
