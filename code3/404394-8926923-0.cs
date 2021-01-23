    static class SubstringExtensions
    {  
    
        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
    	int posA = value.LastIndexOf(a);
    	if (posA == -1)
    	{
    	    return "";
    	}
    	int adjustedPosA = posA + a.Length;
    	if (adjustedPosA >= value.Length)
    	{
    	    return "";
    	}
    	return value.Substring(adjustedPosA);
        }
    }
