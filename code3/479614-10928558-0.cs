    enum ItemType { Type1 = 1, Type2 = 2, Type3 = 3 };
    Dictionary<ItemType, List<int>> items = new Dictionary<ItemType, List<int>>();
	items[ItemType.Type1] = new List<int> { 1, 2, 3, 4, 5 };
	items[ItemType.Type2] = new List<int> { 11, 12, 13, 15 };
	items[ItemType.Type3] = new List<int> { 21, 22, 23, 24, 25, 26 };
    // Define upper boundary of iteration
    int max = items.Values.Select(v => v.Count).Max();
    int i = 0, n = 2;
    while (i + n <= max)
    {
        // Skip and Take - to select only next portion of elements, SelectMany - to merge resulting lists of portions
        List<int> res = items.Values.Select(v => v.Skip(i).Take(n)).SelectMany(v => v).ToList();
        i += n;
        // Further processing of res
    }
