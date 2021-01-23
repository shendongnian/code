    public static string ToAzureKeyString(this string str)
    {
    	var sb = new StringBuilder();
    	foreach (var c in str
    		.Where(c => c != '/'
    					&& c != '\\'
    					&& c != '#'
    					&& c != '/'
    					&& c != '?'
    					&& !char.IsControl(c)))
    		sb.Append(c);
    	return sb.ToString();
    }
