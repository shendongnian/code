    string longPattern = culture.DateTimeFormat.LongTimePattern;
    if (!longPattern.Contains(":ss"))
    {
        // ???? Throw an exception? Test this with all system cultures, but be aware
        // that you might see custom ones...
    }
    // Only do it if the long pattern doesn't already contain .fff... although if
    // it does, you might want to replace it using the culture's decimal separator...
    if (!longPattern.Contains(".fff"))
    {
        longPattern = longPattern.Replace(":ss", 
            ":ss" + culture.NumberFormat.DecimalSeparator + "fff");
    }
    string timeText = time.ToString(longPattern, culture);
