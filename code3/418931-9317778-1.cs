    public static bool Equals(string a, string b)
    {
        /* == is the object equals- not the string equals */
    	return a == b || (a != null && b != null && string.EqualsHelper(a, b));
    }
    public static bool operator ==(string a, string b)
    {
    	return string.Equals(a, b);
    }
