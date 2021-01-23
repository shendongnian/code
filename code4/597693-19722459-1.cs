    public static bool EndsWith(this StringBuilder haystack, string needle)
    {
        var needleLength = needle.Length - 1;
        var haystackLength = haystack.Length - 1;
        if (haystackLength < needleLength)
        {
            return false;
        }
        for (int i = 0; i < needleLength; i++)
        {
            if (haystack[haystackLength - i] != needle[needleLength - i])
            {
                return false;
            }
        }
        return true;
    }
