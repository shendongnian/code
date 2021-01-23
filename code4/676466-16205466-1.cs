    public static class BooleanParser
    {
        public static bool SafeParse(string value)
        {
            var s = (value ?? "").Trim().ToLower();
            return s == "true" || s == "1";
        }
    }
------------------
    static readonly HashSet<string> _booleanTrueStrings = new HashSet<string> { "true", "yes", "1" };
    static readonly HashSet<string> _booleanFalseStrings = new HashSet<string> { "false", "no", "0" };
    public static bool ToBoolean(string value)
    {
        var v = value?.ToLower()?.Trim() ?? "";
        if (_booleanTrueStrings.Contains(v)) return true;
        if (_booleanFalseStrings.Contains(v)) return false;
        throw new ArgumentException("Unexpected Boolean Format");
    }
