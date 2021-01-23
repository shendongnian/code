    public static decimal FindBestSubsequence (this IEnumerable<decimal> source, out int startIndex, out int endIndex)
    {
        decimal result = decimal.MinValue;
        decimal sum = 0;
        int tempStart = 0;
        List<decimal> tempList = new List<decimal>(source);
        startIndex = 0;
        endIndex = 0;
        for (int index = 0; index < tempList.Count; index++)
        {
            sum += tempList[index];
            if (sum > result)
            {
                result = sum;
                startIndex = tempStart;
                endIndex = index;
            }
            if (sum < 0)
            {
                sum = 0;
                tempStart = index + 1;
            }
        }
        return result;
    }
