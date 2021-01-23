    public static decimal Hours(string s)
    {
        decimal r;
        if (decimal.TryParse(s, out r))
            return r;
        var parts = s.Split(':');
        return (decimal)new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]),0).TotalHours;
    }
