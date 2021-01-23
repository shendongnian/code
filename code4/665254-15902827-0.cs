    private static IEnumerable<int> GetCollection()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return ran.Next(i, 20);
        }
    }
