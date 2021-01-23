    // Assumptions:
    //  (1) All non-negative, or at least you don't mind them in your sum
    //  (2) Items greater than the sum are returned by their lonesome
    static IEnumerable<IEnumerable<int>> GroupBySum(this IEnumerable<int> source,
        int sum)
    {
        var running = 0;
        var items = new List<int>();
        foreach (var x in source)
        {
            if (running + x > sum && items.Any())
            {
                yield return items;
                items = new List<int>();
                running = 0;
            }
            running += x;
            items.Add(x);
        }
        if (items.Any()) yield return items;
    }
