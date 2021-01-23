    foreach (var ss in SubSets(data))
    {
        Console.WriteLine(String.Join("; ",ss));
    }
    IEnumerable<IEnumerable<T>> SubSets<T>(IEnumerable<T> enumerable)
    {
        List<T> list = enumerable.ToList();
        ulong upper = (ulong)1 << list.Count;
        for (ulong i = 0; i < upper ; i++)
        {
            List<T> l = new List<T>(list.Count);
            for (int j = 0; j < sizeof(ulong)*8; j++)
            {
                if (((ulong)1 << j) >= upper) break;
                if (((i >> j) & 1) == 1)
                {
                    l.Add(list[j]);
                }
            }
            yield return l;
        }
    }
