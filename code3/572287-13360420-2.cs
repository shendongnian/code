    public static string SafeToAbsolute(string path)
    {
        var madeSafe = path.Replace("?", "UNLIKELY_TOKEN");
        var absolute = VirtualPathUtility.ToAbsolute(madeSafe);
        var restored = absolute.Replace("UNLIKELY_TOKEN", "?");
        return restored;
    }
