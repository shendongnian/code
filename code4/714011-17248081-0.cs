    public static IEnumerable<int> Range(int count, int start = 0, int step = 1)
    {
        for (int i = start; i < count; i++)
            yield return i;
    }
    var arr = Range(4, 0, 5).ToArray(); // 0, 5, 10, 15.
