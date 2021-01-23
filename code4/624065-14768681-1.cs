    public static bool ElementAtPosContains(this string inputStr, int index, string[] valuesToCheck)
    {
        if (valuesToCheck == null || inputStr.Length < index)
            return false;
        IList<string> candidates = valuesToCheck
            .Where(s => s.Length + index <= inputStr.Length)
            .ToList();
        return candidates.Any(c => inputStr.IndexOf(c, index) == index) ;
    }
