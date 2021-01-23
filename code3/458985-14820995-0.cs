    public static IEnumerable<IEnumerable<T>> Subsets(IEnumerable<T> source)
    {
        List<T> list = source.ToList();
        int length = list.Count;
        int max = (int)Math.Pow(2, list.Count);
        for (int count = 0; count < max; count++)
        {
            List<T> subset = new List<T>();
            uint rs = 0;
            while (rs < length)
            {
                if ((count & (1u << (int)rs)) > 0)
                {
                    subset.Add(list[(int)rs]);
                }
                rs++;
            }
            yield return subset;
        }
    }
