    private readonly static List<int?> Source = new List<int?>(){1,2,3,4,5,6};
    private static IEnumerable<int?> ReadNumbers()
    {
        while (Source.Count > 0) {
            yield return Source.ElementAt(0);
            Source.RemoveAt(0);
        }
    }
