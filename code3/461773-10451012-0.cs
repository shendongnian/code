    private static int[] MergeSorted(IEnumerable<int[]> sortedInts)
    {
        var results = new List<int[]>(sortedInts);
        results.Sort((list1, list2) => list1.Length.CompareTo(list2.Length));
        while (results.Count > 1)
        {
            for (var x = 0; x < results.Count; x++)
            {
                if (results.Count == 0 || x == results.Count - 1)
                {
                    continue;
                }
                var res = new List<int>(results[x]);
                var index = 0;
                for (var j = 0; j < results[x + 1].Length; j++)
                {
                    for (; index < res.Count; index++)
                    {
                        if (results[x + 1][j] <= res[index])
                        {
                            break;
                        }
                    }
                    res.Insert(index++, results[x + 1][j]);
                }
                results.RemoveAt(x);
                results[x] = res.ToArray();
            }
        }
        return results[0];
    }
