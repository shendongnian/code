    private IEnumerable<int[]> CombinationsFor(int n, int k);
    private int CombinationsCount(int n, int k);
    private int IndexFor(int n, int[] combination)
    {
        int k = combination.Count();
        int ret = 0;
        int j = 0;
        for (int i = 0; i < k; i++)
        {
            for (j++; j < combination[i]; j++)
            {
                ret += CombinationsCount(n - j, k - i - 1);
            }
        }
        return ret;
    }
    private IEnumerable<int> PossibleCombinations(int n, int k, int[] picked)
    {
        int m = picked.Count();
        int[] reverseMapping = Enumerable.Range(0, n)
            .Where(i=>!picked.Contains(i))
            .ToArray();
        return CombinationsFor(n-m, k-m)
            .Select(c => c
                .Select(x=>reverseMapping[x])
                .Concat(picked)
                .OrderBy(x=>x)
                .ToArray()
            )
            .Select(c => IndexFor(n, c));
    }
