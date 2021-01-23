    public static IList<int> AllIndexOf(this string text, string str, StringComparison comparisonType)
    {
        IList<int> allIndices = new List<int>();
        int index = text.IndexOf(str, comparisonType);
        while(index != -1)
        {
            allIndices.Add(index);
            index = text.IndexOf(str, index + str.Length, comparisonType);
        }
        return allIndices;
    }
