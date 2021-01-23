    var culture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
    // Make the AM/PM designators lowercase
    culture.DateTimeFormat.AMDesignator = culture.DateTimeFormat.AMDesignator.ToLower();
    culture.DateTimeFormat.PMDesignator = culture.DateTimeFormat.PMDesignator.ToLower();
    var dDateFormatPattern = culture.DateTimeFormat.ShortDatePattern;
    var tDateFormatPattern = culture.DateTimeFormat.ShortTimePattern;
    var dateCompact = dDateFormatPattern.Replace("yyyy", "")
        .Replace("MM", "M").Replace("dd", "d").Replace(" ", "")
        .Trim(culture.DateTimeFormat.DateSeparator.ToArray());
    var timeCompact = tDateFormatPattern
        .Replace("hh", "h").Replace("tt", "t").Replace(" ", "");
    Console.WriteLine(DateTime.Now.ToString(dateCompact + " " + timeCompact, culture));
    >>> 4/4 3:03p
