    static IEnumerable<int> GetNumbers()
    {
        for (int i = 1; i < 10; i += 2)
        {
            yield return i;
        }
    }
