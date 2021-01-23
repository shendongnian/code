    public static IEnumerable<IEnumerable<int>> Foo(int[][] data)
    {
        var items = new HashSet<int>();
        foreach (var array in data)
        {
            yield return array.Except(items);
            items.UnionWith(array);
        }
    }
