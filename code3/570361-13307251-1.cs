    public static string TrimmedOrDefault(this string str, string def)
    {
        if (string.IsNullOrEmpty(str)) //or if (string.IsNullOrWhitespace(str))
        {
            // Hmm... what if def is null or empty?
            // Well, I guess that's what the caller wants.
            return def; 
        }
        else
        {
            return str.Trim();
        }
    }
