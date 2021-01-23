    public static int StringDistance(string first, string second)
    {
        int result = 0;
        for (int i = 0; i < first.Length; i++)
        {
            if (!first[i].Equals(second[i]))
            {
                result++;
            }
        }
        return result;
    }
