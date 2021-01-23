    public void GetMax()
    {
        var a = new[]
                    {
                        new[] {1, 202, 4, 55},
                        new[] {40, 7},
                        new[] {2, 48, 5},
                        new[] {40, 8, 90}
                    };
        var result = GetMaxRecursive(a, 0);
    }
    private static int[][] GetMaxRecursive(int[][] a, int level)
    {
        a = a.Where(x=>x.Length > level).ToArray();
        var max = a.Max(x =>x[level]);
        var m = a.Where(x => x[level] == max).ToArray();
        return m.Length > 1
                    ? GetMaxRecursive(m, ++level)
                    : m;
    }
