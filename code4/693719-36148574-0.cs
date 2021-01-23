    public static string GetReadableTimeSpan(TimeSpan span)
    {
    	var formatted = string.Format("{0}{1}{2}{3}",
    		span.Duration().Days > 0
    			? $"{span.Days:0} Tag{(span.Days == 1 ? string.Empty : "e")}, "
    			: string.Empty,
    		span.Duration().Hours > 0
    			? $"{span.Hours:0} Stunde{(span.Hours == 1 ? string.Empty : "n")}, "
    			: string.Empty,
    		span.Duration().Minutes > 0
    			? $"{span.Minutes:0} Minute{(span.Minutes == 1 ? string.Empty : "n")}, "
    			: string.Empty,
    		span.Duration().Seconds > 0
    			? $"{span.Seconds:0} Sekunde{(span.Seconds == 1 ? string.Empty : "n")}"
    			: string.Empty);
    
    	if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);
    
    	return string.IsNullOrEmpty(formatted) ? "0 Sekunden" : ReplaceLastOccurrence(formatted, ",", " und ").Replace("  ", " ");
    }
    
    private static string ReplaceLastOccurrence(string source, string find, string replace)
    {
    	var place = source.LastIndexOf(find, StringComparison.Ordinal);
    
    	if (place == -1)
    		return source;
    
    	var result = source.Remove(place, find.Length).Insert(place, replace);
    	return result;
    }
