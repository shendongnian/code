    IEnumerable<int> GetMultiples(int max)
    {
        return Enumerable.Range(1, max / 3)
                         .Select(p => p * 3)
                         .Concat((max %= 3) == 0 ? new int[0] : new int[] { max });
    }
