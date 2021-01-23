    public static string ToName(this char c)
    {
        string result = ""; // or "unknown" or null or whatever
        _charToName.TryGetValue(c, out result);
        return result;
    }
    // ...
    string name = c.ToName();
