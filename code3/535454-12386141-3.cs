    if (formatString.Length == 1)
    {        
        // Get formatter for the culture of your choice - e.g. the current culture
        DateTimeFormatInfo fi = CultureInfo.CurrentCulture.DateTimeFormat;
    
        // Replace standard format string with correpsonding custom equivalent.
        // Use reflection to do this the same way DateTime.ToString does.
        // Get this MethodInfo into a class variable if you're using it more
        // than once and it's too slow.
        var methodInfo = Assembly.GetAssembly(typeof(System.DateTime))
            .GetType("System.DateTimeFormat")
            .GetMethod(
                "ExpandPredefinedFormat",
                BindingFlags.Static | BindingFlags.NonPublic);
        formatString = methodInfo.Invoke(
            null,
            new object[]{
                formatString,
                DateTime.MinValue,
                fi,
                TimeSpan.MinValue});
    }
    // Check custom format string for presence of 12/24 hour specifiers.
    bool is12Hour = formatString.Contains("h");
    bool is24Hour = formatString.Contains("H");
