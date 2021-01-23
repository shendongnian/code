    private static void PrintHeaders(IEnumerable<HeaderItem> headerItems, int depth = 0)
    {
        var result =
            headerItems.Where(h => h.Length > depth).GroupBy(h => h[depth], h => h,
                                                                (k, g) => new {Key = k, Items = g}).OrderBy(g => g.Key);
        foreach (var pair in result)
        {
            Console.Write(new string('.', depth));
            Console.WriteLine(pair.Key);
            PrintHeaders(pair.Items, depth + 1);
        }
    }
