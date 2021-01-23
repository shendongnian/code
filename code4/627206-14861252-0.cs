    static void RemoveDupes(ref Array a1, ref Array a2, ref Array a3)
    {
        Type a1t, a2t, a3t;
        int newLength, ni, oi;
        int[] indices;
        a1t = a1.GetType().GetElementType();
        a2t = a1.GetType().GetElementType();
        a3t = a1.GetType().GetElementType();
        Dictionary<object, List<int>> buckets = new Dictionary<object, List<int>>();
        for (int i = 0; i < a1.Length; i++)
        {
            object val = a1.GetValue(i);
            if (buckets.ContainsKey(val))
                buckets[val].Add(i);
            else
                buckets.Add(val, new List<int> { i });
        }
        indices = buckets.Where(kvp => kvp.Value.Count > 1).SelectMany(kvp => kvp.Value.Skip(1)).OrderBy(i => i).ToArray();
        newLength = a1.Length - indices.Length;
        Array na1 = Array.CreateInstance(a1t, newLength);
        Array na2 = Array.CreateInstance(a2t, newLength);
        Array na3 = Array.CreateInstance(a3t, newLength);
        oi = 0;
        ni = 0;
        for (int i = 0; i < indices.Length; i++)
        {
            while (oi < indices[i])
            {
                na1.SetValue(a1.GetValue(oi), ni);
                na2.SetValue(a2.GetValue(oi), ni);
                na3.SetValue(a3.GetValue(oi), ni);
                oi++;
                ni++;
            }
            oi++;
        }
        while (ni < newLength)
        {
            na1.SetValue(a1.GetValue(oi), ni);
            na2.SetValue(a2.GetValue(oi), ni);
            na3.SetValue(a3.GetValue(oi), ni);
            oi++;
            ni++;
        }
        a1 = na1;
        a2 = na2;
        a3 = na3;
    }
