    internal class Combination
    {
        internal int Num;
        internal IEnumerable<Combination> Combinations;
    }
    
    internal static IEnumerable<Combination> GetCombinationTrees(int num, int max)
    {
        if (num > 0)
        {
            return Enumerable.Range(1, num)
                             .Where(n => n <= max)
                             .Select(n => 
                                 new Combination { 
                                     Num = n, 
                                     Combinations = GetCombinationTrees(num - n, n) 
                                 });
        }
        else
        {
            return new Combination[0];
        }
    }
    
    internal static IEnumerable<IEnumerable<int>> BuildCombinations(
                                                 IEnumerable<Combination> combinations)
    {
        if (combinations.Count() > 0)
        {
            List<IEnumerable<int>> items = new List<IEnumerable<int>>();
            foreach (Combination c in combinations)
            {
                items.AddRange(
                       BuildCombinations(c.Combinations)
                                              .Select(l => l.Concat(new[] { c.Num })
                       )
                );
            }
            return items;
        }
        else
        {
            return new[] { new int[0] };
        }
    }
    
    public static IEnumerable<IEnumerable<int>> GetCombinations(int num)
    {
        var combinationsList = GetCombinationTrees(num, num);
    
        return BuildCombinations(combinationsList);
    }
    
    public static void PrintCombinations(int num)
    {
        var allCombinations = GetCombinations(num);
        foreach (var c in allCombinations)
        {
            Console.WriteLine(string.Join(", ", c));
        }
    }
