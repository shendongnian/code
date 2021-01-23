    public DateTime ConvertFromUtcToCentral(string UtcTime)
    {
        return !string.IsNullOrEmpty(UtcTime)
            ? this.ConvertFromUtcToCentral(Convert.ToDateTime(UtcTime))
            : default(DateTime);
    }
    public DateTime? ConvertFromUtcToCentral(DateTime? UtcTime)
    {
        return UtcTime.HasValue
            ? this.ConvertFromUtcToCentral(UtcTime.Value)
            : (DateTime?)null;
    }
    public DateTime ConvertFromUtcToCentral(DateTime UtcTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(UtcTime, USTimeZones.Central);
    }
