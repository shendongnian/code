    public static string ToMyFormat(this TimeSpan ts)
    {
        string format = ts.Days >= 1 ? "d'.'hh':'mm" : "hh':'mm";
        return ts.ToString(format);
    }
