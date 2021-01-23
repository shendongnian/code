    public static int StringDistance(string first, string second)
    {
        char[] firstArray = first.ToCharArray();
        char[] secondArray = second.ToCharArray();
        int result = 0;
        for (int i = 0; i < first.Length; i++)
        {
            if (!firstArray[i].Equals(secondArray[i]))
            {
                result++;
            }
        }
        return result;
    }
