    public static bool ElementAtPosContains(this string inputStr, int index, IList<String> valuesToCheck)
    {
        if (valuesToCheck == null || inputStr.Length < index)
            return false;
        valuesToCheck = valuesToCheck
            .Where(s => s.Length + index <= inputStr.Length)
            .ToList();
        return valuesToCheck.Any(c => inputStr.IndexOf(c, index) == index);
    }
