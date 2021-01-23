    Parallel.Invoke(() => FillDictionary(dict1, 1000000), () => FillDictionary(dict2, 1000000));
    ...
    private static void FillDictionary(Dictionary<int, string> toFill, int itemCount)
    {
        for(int i = 0 ; i < itemCount; i++)
            toFill.Add(i, "test" + i);
    }
