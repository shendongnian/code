    public static IEnumerable<List<T>> BatchBy<T>(this IEnumerable<T> enumerable, int batchSize)
    {
        using (var enumerator = enumerable.GetEnumerator())
        {
            List<T> list = null;
            while (enumerator.MoveNext())
            {
                if (list == null)
                {
                    list = new List<T> {enumerator.Current};
                }
                else if (list.Count < batchSize)
                {
                    list.Add(enumerator.Current);
                }
                else
                {
                    yield return list;
                    list = new List<T> {enumerator.Current};
                }
            }
            if (list?.Count > 0)
            {
                yield return list;
            }
        }
    }
