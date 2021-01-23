    foreach (var ss in SubSets(data))
    {
        Console.WriteLine(String.Join("; ",ss));
    }
    IEnumerable<IEnumerable<T>> SubSets<T>(IEnumerable<T> enumerable)
    {
        List<T> list = enumerable.ToList();
        for (long i = 0; i < Math.Pow(list.Count, 2); i++)
        {
            List<T> l = new List<T>();
            for (int j = 0; j < sizeof(ulong); j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    l.Add(list[j]);
                }
            }
            yield return l;
        }
    }
