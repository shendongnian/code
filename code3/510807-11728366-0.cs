    private static String GetColorName(Color color)
    {
        var predefined = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
        var match = (from p in predefined where ((Color)p.GetValue(null, null)).ToArgb() == color.ToArgb() select (Color)p.GetValue(null, null));
        if (match.Any())
           return match.First().Name;
        return String.Empty;
    }
