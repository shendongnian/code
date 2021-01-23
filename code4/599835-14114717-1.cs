    public static class ExtensionMethod
    {
	    public static bool ContainsAny(this string str, params string[] values)
	    {
		    return values.Any(x => str.Contains(x));
	    }
    }
