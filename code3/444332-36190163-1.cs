    public static string ReadableTime(int milliseconds)
    {
        var parts = new List<string>();
        Action<int, string> add = (val, unit) => { if (val > 0) parts.Add(val+unit); };
        var t = TimeSpan.FromMilliseconds(milliseconds);
        add(t.Days, "d");
        add(t.Hours, "h");
        add(t.Minutes, "m");
        add(t.Seconds, "s");
        add(t.Milliseconds, "ms");
        return string.Join(" ", parts);
    }
