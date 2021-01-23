    public static IEnumerable<DateTime> GetQuarterDates()
    {
        for (DateTime quarterDate = DateTime.Now.AddYears(-4); quarterDate < DateTime.Now; quarterDate = quarterDate.AddMonths(3))
        {
            yield return quarterDate; 
        }
    }
        var quarters = GetQuarterDates().Select(quarterDate => new { Year = quarterDate.Year, Quarter = quarterDate.Month / 3 });
