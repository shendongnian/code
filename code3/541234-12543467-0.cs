    public static string ToMyFormat(this TimeSpan ts)
    {
        var sb = new StringBuilder();
        if (ts.Days >= 1)
            sb.Append("d'.'");
        sb.Append("hh':'mm");
        return ts.ToString(sb.ToString());
    }
