    public static IEnumerable<int> Range(int start, int end)
    {
        for(int i = start; i < end; i++)
        {
            yield return i;
        }
    }
