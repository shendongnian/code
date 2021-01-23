    static IEnumerable<List<int>> GetCombinations(IEnumerable<List<int>> lists, IEnumerable<int> selected)
    {
        if (lists.Count() == 1)
        {
            // Last list, emit a new combination if found
            foreach (var item in lists.Last().Where(x => !selected.Contains(x)))
            {
                yield return selected.Union(new int[] { item }).ToList();
            }
        }
        else
        {
            var remainingLists = lists.Skip(1).ToList();
            foreach (var item in lists.First().Where(x => !selected.Contains(x)))
            {
                var combinations = GetCombinations(remainingLists, selected.Union(new int[] { item }).ToList());
                foreach (var combination in combinations)
                    yield return combination;
            }
        }
    }
    
    static void Main(string[] args)
    {
        List<List<int>> lists = new List<List<int>>
        {
            new List<int> { 1, 3, 6 },
            new List<int> { 1, 2, 6 },
            new List<int> { 1 },
            new List<int> { 2, 3 }
        };
    
        var combinations = GetCombinations(lists, new List<int>());
    
        foreach (var combination in combinations)
            Console.WriteLine("{ " + string.Join(", ", combination.Select(x => x.ToString())) + " }");
    
        return;
    }
