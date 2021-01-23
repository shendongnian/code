    public static string Reverse(this string source)
    {
	    char[] arr = source.ToCharArray();
	    Array.Reverse(arr);
	    return new string(arr);
    }
    
