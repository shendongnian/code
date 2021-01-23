    HashSet<string> remaining = new HashSet<string>(b);
    List<Tuple<string, int>> pairs = new List<Tuple<string, int>>();
    for (int i = 0; i < a.Length; i++)
    {
        if (remaining.Remove(a[i]))
        {
            pairs.Add(Tuple.Of(a[i], i));
        }
    }
