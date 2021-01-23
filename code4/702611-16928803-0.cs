    private static List<int[]> GetGroups(List<int> numberList)
    {
        List<List<int>> groups = new List<List<int>>();
        numberList.Zip(numberList.Skip(1), (a, b) =>
        {
            if ((b - a) == 30)
            {
                if (groups.Count == 0)
                    groups.Add(new List<int>());
                groups[groups.Count - 1].Add(a);
            }
            else if (a == b)
            {
                groups[groups.Count - 1].Add(a);
            }
            else
            {
                groups[groups.Count - 1].Add(a);
                groups.Add(new List<int>());
            }
            return a;
        }).ToList();
        groups[groups.Count - 1].Add(numberList.Last());
        return groups.Select(g => new[] { g.First(), g.Last() }).ToList();
    }
