    public static bool ContainsDuplicateCharacter(this string s, char c)
    {
        bool seenFirst = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != c)
                continue;
            if (seenFirst)
                return true;
            seenFirst = true;
        }
        return false;
    }
