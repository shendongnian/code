    public static bool IsIn(this string value, IEnumerable<string> compareList)
    {
       foreach (string compareValue in compareList)
       {
            if (value.Contains(compareValue))
                    return true;
       }
            return false;
    }
