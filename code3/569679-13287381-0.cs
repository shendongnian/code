    List<List<int>> lists = new List<List<int>>();
    lists.Add(new List<int>(new int[] { 3, 5, 7 }));
    lists.Add(new List<int>(new int[] { 3, 5, 6 }));
    lists.Add(new List<int>(new int[] { 2, 9 }));
    int listCount = lists.Count;
    List<int> indexes = new List<int>();
    for (int i = 0; i < listCount; i++)
        indexes.Add(0);
    while (true)
    {
        // construct values
        int[] values = new int[listCount];
        for (int i = 0; i < listCount; i++)
            values[i] = lists[i][indexes[i]];
        Console.WriteLine(string.Join(" ", values));
        // increment indexes
        int incrementIndex = listCount - 1;
        while (incrementIndex >= 0 && ++indexes[incrementIndex] >= lists[incrementIndex].Count)
        {
            indexes[incrementIndex] = 0;
            incrementIndex--;
        }
        // break condition
        if (incrementIndex < 0)
            break;
    }
