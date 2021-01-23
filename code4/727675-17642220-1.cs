    static IEnumerable<List<int>> GetCombinations(IEnumerable<List<int>> lists, IEnumerable<int> selected)
    {
        if (lists.Any())
        {
            var remainingLists = lists.Skip(1);
            foreach (var item in lists.First().Where(x => !selected.Contains(x)))
                foreach (var combo in GetCombinations(remainingLists, selected.Concat(new int[] { item })))
                    yield return combo;
        }
        else
        {
            yield return selected.ToList();
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
    
        var combos = GetCombinations(lists, new List<int>()).Distinct();
    
        foreach (var combo in combos)
            Console.WriteLine("{ " + string.Join(", ", combo.Select(x => x.ToString())) + " }");
    
        return;
    }
