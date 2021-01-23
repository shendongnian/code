    public static string[] GetStringInBetween(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)
    {
        string[] result = { "", "" };
        int iIndexOfBegin = strSource.IndexOf(strBegin, StringComparison.Ordinal);
        if (iIndexOfBegin != -1)
        {
            int iEnd = strSource.IndexOf(strEnd, iIndexOfBegin, StringComparison.Ordinal);
            if (iEnd != -1)
            {
                result[0] = strSource.Substring(
                    iIndexOfBegin + (includeBegin ? 0 : strBegin.Length), 
                    iEnd + (includeEnd ? strEnd.Length : 0) - iIndexOfBegin);
                // advance beyond this segment
                if (iEnd + strEnd.Length < strSource.Length)
                    result[1] = strSource.Substring(iEnd + strEnd.Length);
            }
        }
        return result;
    }
