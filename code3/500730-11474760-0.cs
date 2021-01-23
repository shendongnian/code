    static void Main()
    {
        var words = new List<string> {"w1", "w2", "w3", "w4", "w5", "w6", "w7"};
        foreach (var list in Generate(words, 3))
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
    static IEnumerable<List<string>> Generate(List<string> words, int length, int ix = 0, int[] indexes = null)
    {
        indexes = indexes ?? Enumerable.Range(0, length).ToArray();
        if (ix > 0)
            yield return indexes.Take(ix).Select(x => words[x]).ToList();
        if (ix > length)
            yield break;
        if (ix == length)
        {
            yield return indexes.Select(x => words[x]).ToList();
        }
        else
        {
            for (int jx = ix > 0 ? indexes[ix-1]+1 : 0; jx < words.Count; jx++)
            {
                indexes[ix] = jx;
                foreach (var list in Generate(words, length, ix + 1, indexes))
                    yield return list;
            }
        }
    }
