    public class static Extension
    {
        public static int CountStringOccurrences(this string text, string pattern)
            {
        	// Loop through all instances of the string 'text'.
        	int count = 0;
        	int i = 0;
        	while ((i = text.IndexOf(pattern, i)) != -1)
        	{
        	    i += pattern.Length;
        	    count++;
        	}
        	return count;
            }
    }
