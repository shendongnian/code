    public string GetAnniversaryString(DateTime startDate)
    {
        var next = GetNextAnniversary(startDate);
        int nYears = next.Year - startDate.Year;
        var span = next - DateTime.Now;
        return span.Days <= 30 
            ? string.Format("{0} year anniversary in {1} days", nYears, span.Days)
            : string.Empty;
    }
