    static string[] formats; //made static for performance reasons
    private static DateTime ParseOrDefault(string value)
    {
        formats = formats ?? GetDateTimeFormats();
        DateTime result;
        var sett = DateTimeStyles.AllowWhiteSpaces; //and whatever that is
        if (!DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, sett, out result))
            return Convert.ToDateTime("01/01/1700", CultureInfo.InvariantCulture);
        return result;
    }
    static string[] GetDateTimeFormats()
    {
        var allFormats = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                    .SelectMany(x => x.DateTimeFormat.GetAllDateTimePatterns())
                                    .Distinct(); //to speed up things
        //discard some formats that're not worthy of consideration
        var goodFormats = allFormats.Where(x => !IsConflictingFormat(x));
        return goodFormats.ToArray();
    }
    //to remove conflicting date formats, for example, 
    //formats like MM-dd-yy, yy-MM-dd, dd-MM-yy etc can be conflicting
    static bool IsConflictingFormat(string format)
    {
        //in this example we discard formats like M-d-yy, yy-MM-dd etc, but keep dd-MM-yy
        //in case you want to keep MM-dd-yy, the placeholders array should be { 'd', 'y' },
        //and similarly if the preferred format is yy-MM-dd, array should be { 'M', 'd' }
        var placeholders = new[] { 'M', 'y' };
        var separators = new[] { ' ', '.', '-', '/' };
        var patterns = placeholders.Select(x => x.ToString())
                                   .SelectMany(x => new[] { x, x + x })
                                   .SelectMany(x => separators, (x, y) => x + y);
        return patterns.Any(format.StartsWith);
    }
