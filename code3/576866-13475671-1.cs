    public static int[] algorithm(int[] numbers, int[] counts)
    {
        var pairs = numbers                         // EDIT:
            .Zip(counts, (n, c) => new { n, c })    // This is needed to
            .OrderBy(p => p.n)                      // correctly handle
            .ThenBy(p => p.c)                       // duplicate numbers
            .ToArray();
        int[] output = new int[pairs.Length];
        List<int> freeIndices = Enumerable.Range(0, pairs.Length).ToList();
        for (int i = 0; i < pairs.Length; i++)
        {
            if (pairs[i].c < freeIndices.Count)
            {
                int outputIndex = freeIndices[pairs[i].c];
                freeIndices.RemoveAt(pairs[i].c);
                output[outputIndex] = pairs[i].n;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        return output;
    }
