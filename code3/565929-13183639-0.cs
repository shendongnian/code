    int N = 3;
    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var ListOfLists = list.Select((x, inx) => new { Item = x, Group = inx / N })
                            .GroupBy(g => g.Group, g => g.Item)
                            .Select(x => x.ToList())
                            .ToList();
